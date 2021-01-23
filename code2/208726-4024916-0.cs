    XmlDocument xmlDoc = new XmlDocument();
    try    {
        xmlDoc.Load(serializedFile);
    }
    catch (XmlException exc) {
        // Handle the error
    }
	
    StringWriter stringWriter = new StringWriter();
    XmlTextWriter xmlWriter= new XmlTextWriter(stringWriter);
    xmlDoc.WriteTo(xmlWriter);
    myObject.OriginalXML = xmlWriter.ToString();
