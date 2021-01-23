    var doc= XDocument.Load(xmlFile);
    
    XNamespace dNs = "http://actual-d-namespace-uri";
    
    foreach(var element in doc.Root.Elements(dNs + "REQUIREMENT_SPECIFICATION"))
    {
    	var attributes = element.Attributes()
                                .Select(a => string.Format("{0}: {1}", a.Name, a.Value));
    	
    	Console.WriteLine("Requirement Specification " + string.Join(" ", attributes));
    }
