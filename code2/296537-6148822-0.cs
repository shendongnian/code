    string xml = @"<parameters>
      <source value=""mysource"" />
      <name value=""myname"" />
      <id value=""myid"" />
    </parameters>";
    
    var doc = XDocument.Parse(xml);
    IDictionary dict = doc.Element("parameters")
      .Elements()
      .ToDictionary(
        d => d.Name.ToString(), 
        l => l.Attribute("value").Value);
        
