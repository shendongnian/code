    public String sqlReading(String fileName, String path, String nodeId)
    {
    	XmlDocument doc = new XmlDocument();
    	doc.Load(fileName);
    
    	XmlNode foundNode = doc.SelectNodes(path).SelectSingleNode("*[@id='" + nodeId + "']/GUIDisplay/sqlSearchString");
    	if (foundNode != null)
    		return foundNode.InnerText;
    	return string.Empty;
    
    }
