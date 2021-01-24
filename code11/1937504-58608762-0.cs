    void Main()
    {
    	string outputXMLfile = @"e:\temp\XMLfile_UTF-8.xml";
    
    	XDocument xml = XDocument.Parse(@"<?xml version='1.0' encoding='utf-16'?>
    					<root>
    						<row>some text</row>
    					</root>");
    
    	XDocument doc = new XDocument(
    		new XDeclaration("1.0", "utf-8", null),
    		new XElement(xml.Root)
    	);
    
    
    	XmlWriterSettings settings = new XmlWriterSettings();
    	settings.Indent = true;
    	settings.IndentChars = "\t";
    	// to remove BOM
    	settings.Encoding = new UTF8Encoding(false);
    
    	using (XmlWriter writer = XmlWriter.Create(outputXMLfile, settings))
    	{
    		doc.Save(writer);
    	}
    }
