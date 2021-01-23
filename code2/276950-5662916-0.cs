    void DeleteSelectedItems(TreeView root)
    {
    	var todelete = List<TreeViewItem>();
    	GetSelectedItems(root.Items, todelete);
    	foreach(var it in todelete)
    	{
    		var parent = it.Parent;
    		parent.Items.Remove(it);
    	}
    }
    
    void GetSelectedItems(ItemsCollection tree, List<TreeViewItem> todelete)
    {
    	foreach(var it in tree)
    	{
    		if (((it as TreeViewItem).Header as CheckBox).Checked)
    			todelete.Add(it);
    		else
    			GetSelectedItems(it.Items, todelete);
    	}
    }
