    private void TreeViewItem_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
    	//this will supress the bubbling MouseDoubleClick event 
    	e.Handled = true;
    }
