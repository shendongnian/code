    public static IEnumerable<INode> GetDescendants(this INode node)
    {
    	foreach (INode child in node.ChildrenAsList)
    	{
    		yield return child;
    
    		foreach (INode grandChild in child.GetDescendants())
    		{
    			yield return grandChild;
    		}
    	}
    	yield break;
    }
