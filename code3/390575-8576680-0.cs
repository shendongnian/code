    private static TreeViewItem FindTreeViewSelectedItemContainer(ItemsControl root, object selection)
    {
    	var item = root.ItemContainerGenerator.ContainerFromItem(selection) as TreeViewItem;
    	if (item == null)
    	{
    		foreach (var subItem in root.Items)
    		{
    			item = FindTreeViewSelectedItemContainer((TreeViewItem)root.ItemContainerGenerator.ContainerFromItem(subItem), selection);
    			if (item != null)
    			{
    				break;
    			}
    		}
    	}
    
    	return item;
    }
    
    // Example:
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	if (TV.SelectedItem != null)
    	{
    		var container = FindTreeViewSelectedItemContainer(TV, TV.SelectedItem);
    		if (container != null)
    		{
    			container.IsSelected = false;
    		}
    	}
    }
