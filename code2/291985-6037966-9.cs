    private void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
    	if (e.ClickCount > 1)
    	{
    		//here you would probably want to include code that is called by your
    		//mouse down event handler.
    		e.Handled = true;
    	}
    }
