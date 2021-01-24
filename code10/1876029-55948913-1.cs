    private void TextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
    	if (e.Key.ToString().Equals("Back"))
    	{
    		e.Handled = false;
    		return;
    	}
    	for (int i = 0; i < 10; i++)
    	{
    		if (e.Key.ToString() == string.Format("Number{0}", i))
    		{
    			e.Handled = false;
    			return;
    		}
    	}
    	e.Handled = true;
    }
