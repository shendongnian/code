    public void SetNodeValues(Node node)
    {
    	if (node.Name == String.Empty)
    	{
    		//If it has no name it is a leaf, which needs no value
    		return;
    	}
    	else
    	{
    		//Make sure all child-nodes have values
    		foreach (var childNode in node.ChildNodes)
    		{
    			SetNodeValues(childNode);
    		}
    		
    		//Sum them up and set that as the current node's value
    		node.Value = node.ChildNodes.Sum(x => x.Value);
    	}
    }
