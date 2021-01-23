    [WebMethod]
    public void CreateTable(string infoPathData)
    {
    	var doc = new XmlDocument();
        doc.LoadXml(infoPathData);
    
    	//gets the namespace uri - it is unique for each form
    	string nsUri = doc.ChildNodes[3].Attributes["xmlns:my"].Value;
        
    	var nsManager = new XmlNamespaceManager(doc.NameTable);
    	nsManager.AddNamespace("my", nsUri);
    
        //select the myField node
        var root = doc.SelectSingleNode("my:myFields", nsManager);
    
        var sqlStatement = new StringBuilder();
        sqlStatement.Append("CREATE TABLE ....");
    
    	foreach (XmlNode n in root.ChildNodes)
        {
    		//n.Name - gets the name of the node (incl. NS)
            //n.InnerText - gets the field value 
    		
    		//append to sqlStatement
        }
    
        //execute sql statement ...
    }
