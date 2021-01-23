    public static class extensionMethods
    {
    	public static XElement FindOrAddElement(this XContainer xml, string nodeName)
    	{
    		var node = xml.Descendants().FirstOrDefault(x => x.Name == nodeName);
    		if (node == null)
    			xml.Add(new XElement(nodeName));
    		return xml.Descendants().FirstOrDefault(x => x.Name == nodeName);
    	}
    }
