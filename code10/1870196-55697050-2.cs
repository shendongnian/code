    private static void DeleteXmlNode(string path, string tagname, string searchconditionAttributevalue)
    {
    	XmlDocument doc = new XmlDocument();
    	doc.Load(path);
    	XmlNodeList nodes = doc.GetElementsByTagName(tagname);
    	AddFileSecurity(path, FileSystemRights.ReadData, AccessControlType.Allow);
    
    	XmlNodeList nodes = doc.SelectSingleNode("Jobs").SelectNodes("Job");
    	for (int i = nodes.Count - 1; i >= 0; i--)
    	{
    		 if (nodes[i].Attributes["JobId"] == null) //this statement removes null tags
    		 {
    			 nodes[i].ParentNode.RemoveChild(nodes[i]);
    		 } else if(nodes[i].Attributes["JobId"].Value == searchconditionAttributevalue) //this statement removes selected tag.
    			nodes[i].ParentNode.RemoveChild(nodes[i]);
    	} 	
    	
    	doc.Save(path);
    }
