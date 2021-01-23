    static string GetXmlString(string strFile)
      {
    	// Load the xml file into XmlDocument object.
    	XmlDocument xmlDoc = new XmlDocument();
    	try
    	{
    		xmlDoc.Load(strFile);
    	}
    	catch (XmlException e)
    	{
    		Console.WriteLine(e.Message);
    	}
    	// Now create StringWriter object to get data from xml document.
    	StringWriter sw = new StringWriter();
    	XmlTextWriter xw = new XmlTextWriter(sw);
    	xmlDoc.WriteTo(xw);
    	return sw.ToString();
       } 
