    using System.Xml.Linq;
    // [...]    
    var sourceDoc = XDocument.Load(@"C:\Your\Source\Xml\File.xml");
    var sports = sourceDoc.Descendants().Where(s => s.Name == "Sport");
    
    var destDoc = new XDocument(sports.Select(s =>
    	new XElement("sport",
    		new XElement("id", s.Attribute("id").Value),
    		new XElement("name", s.Attribute("name").Value),
    		new XElement("country",
    			new XAttribute("id", s.Descendants().Where(c => c.Name == "Country").FirstOrDefault().Attribute("id").Value),
    			new XAttribute("name", s.Descendants().Where(c => c.Name == "Country").FirstOrDefault().Attribute("name").Value)
    		)
    	)
    ));
    
    destDoc.Save(@"C:\Your\Destination\Xml\File.xml");
