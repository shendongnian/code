    System.Xml.XmlDocument someXmlFile = new System.Xml.XmlDocument();
    string xmlPath= @"YOUR_XML_FULL_PATH";
    string innerNodeToExtract= @"/Session/SecurityToken";
    try
    {
        // Loading xml file with utf-8 encoding:
        string xmlFileStr= Systm.IO.File.ReadAllText(xmlPath, System.Text.Encoding.UTF8);
        
        // Creating the XPathNavigator:
        System.Xml.XPath.XPathNavigator xmlNavigator= someXmlFile.CreateNavigator();
        // Getting the inner value as string:
        string value = xmlNavigator.SelectSingleNode(innerNodeToExtract).Value;
    
        // some code...
    }
    catch(Exception) 
    {
        // Handle failures
    }
