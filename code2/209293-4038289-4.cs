    private string stripTags(XNode node)
    {
    	if (node is XElement)
    	{
    		XElement elem = (XElement)node;
    		if (elem.Name.ToString().Equals("b", StringComparison.InvariantCultureIgnoreCase))
    		{
    			return elem.ToString();
    		}
    		else
    		{
    			return string.Join(string.Empty, elem.Nodes().Select(n => stripTags(n)).ToArray());
    		}
    	}
    	else
    	{
    		return node.ToString();
    	}
    }
