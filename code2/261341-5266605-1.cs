    public static void TextBoxSelectAll(object sender, KeyEventArgs e)
    {
    	if (e.KeyData == (Keys.Control | Keys.A))
    	{
    		((TextBox)sender).SelectAll();
    
    		e.SuppressKeyPress = true;
    		e.Handled = true;
    	}
    }
