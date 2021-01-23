        String xmlFileName = "Sample.xml";
        // Find the proper path to the XML file
        String xmlFilePath = this.Server.MapPath(xmlFileName);
        // Create an XmlDocument
        System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
    
        // Load the XML file in to the document
        xmlDocument.Load(xmlFilePath);
    
        // Get the target node using XPath
        System.Xml.XmlNode elementToComment = xmlDocument.SelectSingleNode("/configuration/system.web/customErrors");
    
        // Get the XML content of the target node
        String commentContents = elementToComment.OuterXml;
        // Create a new comment node
        // Its contents are the XML content of target node
        System.Xml.XmlComment commentNode = xmlDocument.CreateComment(commentContents);
        // Get a reference to the parent of the target node
        System.Xml.XmlNode parentNode = elementToComment.ParentNode;
        // Replace the target node with the comment
        parentNode.ReplaceChild(commentNode, elementToComment);
        xmlDocument.Save(xmlFilePath);
