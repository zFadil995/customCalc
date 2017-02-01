using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;
using Xamarin.Forms;

namespace codeCalc
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void OnNormalButtonClicked(object sender, EventArgs e)
        {
            ((Button) sender).IsEnabled = false;
            CalculationLine.Text += ((Button) sender).Text;
            ((Button)sender).IsEnabled = true;
        }
        
        private void OnClearClicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            CalculationLine.Text = "";
            ResultLine.Text = "";
            ((Button)sender).IsEnabled = true;
        }

        private void OnPointClicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            if (CalculationLine.Text != "") CalculationLine.Text += ".";
            else CalculationLine.Text = "0.";
            ((Button)sender).IsEnabled = true;
        }

        private void OnEvaluateClicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            ResultLine.Text = (Evaluate(CalculationLine.Text) != "_err") ? Evaluate(CalculationLine.Text) : "Input Error";
            ((Button)sender).IsEnabled = true;
        }

        private static string Evaluate(string expression)
        {
            if (expression == "") expression = "0";
            

            Expression exp = new Expression(expression);
            
            try
            {
                var result = exp.Evaluate();
                return result.ToString();
            }
            catch (Exception)
            {
                return "_err";
            }
        }

    }
}
