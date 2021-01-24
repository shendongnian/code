    var parent = treeData.FirstOrDefault(t => t.Id == item.ParentId);
    if (parent != null)
    {
    	parent.children.Add(new Tree()
    	{
    		Id = item.Id,
    		children = new List<Tree>(),
    		isSelected = item.IsDefault,
    		Name = item.Name
    	});
        // do not add the parent again here
    }
    else 
    {
        // add the parent only if was not found above
        // TODO parent = new Tree(...);
    	treeData.Add(parent);
    }
