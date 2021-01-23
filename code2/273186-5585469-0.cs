    //Load XML
    XmlDocument XDoc = new XmlDocument();
    XDoc.Load(MapPath(@"~\xml\test.xml"));
    
    //Get list of offending nodes
    XmlNodeList Nodes = XDoc.GetElementsByTagName("ARTIST");
    
    //Loop through the list
    while (Nodes.Count != 0) {
        foreach (XmlNode Node in Nodes) {
    		//Remove the offending node
            Node.ParentNode.RemoveChild(Node); //<--This line messes with our iteration and forces us to get a new list after each remove
    		//Stop the loop
            break;
        }
    	//Get a refreshed list of offending nodes
        Nodes = XDoc.GetElementsByTagName("ARTIST");
    }
    //Save the document
    XDoc.Save(newfile);
