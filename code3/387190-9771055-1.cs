    namespace Your_App_Namespace
    {
    
    public static class Globals
    {
        public static double safeval = 0; // variable to save former value!
        public static bool isPositiveNumeric(string strval, System.Globalization.NumberStyles NumberStyle)
        // checking if string strval contains positive number in USER CULTURE NUMBER FORMAT!
        {
            double result;
            boolean test;
            if (strval.Contains("-")) test = false;
            else test = Double.TryParse(strval, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
                   // if (test == false) MessageBox.Show("Not positive number!");
            return test;
        }
        
        public static string numstr2string(string strval, string nofdec)
        // conversion from numeric string into string in USER CULTURE NUMBER FORMAT!
        // call example numstr2string("12.3456", "0.00") returns "12.34"
        {
            string retstr = 0.ToString(nofdec);
            if (Globals.isPositiveNumeric(strval, System.Globalization.NumberStyles.Number)) retstr = double.Parse(strval).ToString(nofdec);
            else retstr = Globals.safeval.ToString(nofdec);
            return retstr;
        }
        
        public static string number2string(double numval, string nofdec)
        // conversion from numeric value into string in USER CULTURE NUMBER FORMAT!
        // call example number2string(12.3456, "0.00") returns "12.34"
        {
            string retstr = 0.ToString(nofdec);
            if (Globals.isPositiveNumeric(numval.ToString(), System.Globalization.NumberStyles.Number)) retstr = numval.ToString(nofdec);
            else retstr = Globals.safeval.ToString(nofdec);
            return retstr;
        }
    }
    
    // Other Your_App_Namespace content
    
    }
    
        // This is the way how to use those functions
    
        // function to call when TextBox GotFocus
        private void textbox_clear(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox txtbox = e.OriginalSource as TextBox;
            // save original value
            Globals.safeval = double.Parse(txtbox.Text);
            txtbox.Text = "";
        }
    
        // function to call when TextBox LostFocus
        private void textbox_change(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox txtbox = e.OriginalSource as TextBox;
            // text from textbox into sting with checking and string format
            txtbox.Text = Globals.numstr2string(txtbox.Text, "0.00");
        }
