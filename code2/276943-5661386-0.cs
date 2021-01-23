    public Node GetBelowNode()
    {
    	if (GetChildrenNodes().count > 0)
    		return GetChildrenNodes()[0];
    	else
    		if (GetNextSiblingNode() != null)
    			return GetNextSiblingNode();
    		else
    		{
    			Node curr = this;
    			Node parent; 
    			while (true)
    			{
    				parent = curr.GetParentNode();
    				if (parent == null)
    					return null;
    				else
    				{
    					if (parent.GetNextSiblingNode() != null)
    						return parent.GetNextSiblingNode();
    					else
    						curr = parent;
    				}
    			}
    		}
    }
