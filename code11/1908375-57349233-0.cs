    void Main()
    {
    	XDocument xml = XDocument.Parse(@"<?xml version='1.0' encoding='utf-16'?>
    					<root>
    						<row>some text</row>
    					</root>");
    	Console.WriteLine(xml.Declaration);
    
    	XDocument doc = new XDocument(
    		new XDeclaration("1.0", "utf-8", null),
    		new XElement(xml.Root)
    	);
    
    	Console.WriteLine(doc.Declaration);
    	Console.WriteLine(doc);
    }
