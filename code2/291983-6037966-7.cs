    private void TreeViewItem_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
    	//this will suppress the event that is causing the nodes to expand/contract 
    	e.Handled = true;
    }
