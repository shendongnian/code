    // Requires reference to HtmlAgilityPack
    public XmlDocument LoadHtmlAsXml(string url)
    {
    	var web = new HtmlWeb();
    
    	var m = new MemoryStream();
    	var xtw = new XmlTextWriter(m, null);
    
    	// Load the content into the writer
    	web.LoadHtmlAsXml(url, xtw);
    
    	// Rewind the memory stream
    	m.Position = 0;
    
    	// Create, fill, and return the xml document
    	XmlDocument xmlDoc = new XmlDocument();
    	xmlDoc.LoadXml((new StreamReader(m)).ReadToEnd());
    	return xmlDoc;
    }
 
