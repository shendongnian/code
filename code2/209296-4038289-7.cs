    private static string stripTags(XNode node)
    {
    	if (node is XElement && !((XElement)node).Name.ToString().Equals("b", StringComparison.InvariantCultureIgnoreCase))
    	{
    		return string.Join(string.Empty, ((XElement)node).Nodes().Select(n => stripTags(n)).ToArray());
    	}
    	else
    	{
    		return node.ToString();
    	}
    }
