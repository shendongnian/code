    // method for updating priority of a item
    public void UpdatePriority(List<Item> items, Item target, Item before)
    {
    	if (before == null)
    	{
    		// append to the end
    		target.Priority.Value = items.Max(x => x.Priority.Value) + 1;
    	}
    	else
    	{
    		target.Priority.Value = before.Priority.Value;
    	}
    }
