    var doc = XDocument.Load("Path to xml file");
    //Or
    var doc = XDocument.Parse(XmlString);
    
    var ns = doc.Root.GetNamespaceOfPrefix("xsi");
    
    var names = doc.Descendants("Items")
        .Elements("Settings")
        .Where(x => x.Attribute(ns + "type").Value == "FileModel")
        .Select(x => x.Element("Name").Value)
        .ToList();
    
    
    names.ForEach(x => Console.WriteLine(x));
