    public static class MyExtensions
    {
    	public static XmlNode ToXmlNode(this XElement element, XmlDocument xmlDoc = null)
    	{
    		using (XmlReader xmlReader = element.CreateReader())
    		{
    			if(xmlDoc==null) xmlDoc = new XmlDocument();
    			return xmlDoc.ReadNode(xmlReader);
    		}
    	}
    }
