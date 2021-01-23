      private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
    	e.Handled = IsTextNumeric(e.Text);
    
    }
    
    
    private static bool IsTextNumeric(string str)
    {
    	System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
    	return reg.IsMatch(str);
    
    }
