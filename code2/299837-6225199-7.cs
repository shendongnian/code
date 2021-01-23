    // To Load Xml Content from File.
    XDocument doc1 = XDocument.Load(@"C:\MyXml.xml");
    
    Collection<string> DependentNodes = new Collection<string>();
    
    var results =
        doc1.Root.Elements("testfixture")
        .Where(x => x.Element("categories").Element("category").Value.Contains("abc_somewords"))
        .Elements("test").Elements("dependencies").Elements("dependson").Attributes("typename").ToArray();
    
    foreach (XAttribute attribute in results)
    {
        DependentNodes.Add(attribute.Value.Trim());
    }
