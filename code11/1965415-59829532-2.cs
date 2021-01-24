    public static bool IsTreeContains(Node node, string itemName)
    {
    	// If the current Node matches
    	if (node.Name == itemName)
    		return true;
    	
    	// End of the Tree or the Node Collection
    	if(node.Nodes.Count == 0)
    		return false;
    
    	foreach (var n in node.Nodes)
    	{
    		if(IsTreeContains(n, itemName))
    			return true;
    		continue;
    	}
    }
