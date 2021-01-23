    public static void TextBoxSelectAll(object sender, KeyEventArgs e)
    {
    	if (e.KeyData.IsFlagSet(Keys.Control | Keys.A))
    	{
    		((TextBox)sender).SelectAll();
    		e.SuppressKeyPress = true;
    	}
    }
