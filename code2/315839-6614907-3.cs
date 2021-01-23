    var doc = XDocument.Load("DataStructure.xml");
    var cols = doc.XPathSelectElements("/datastructure/" + sPageName + "/columns");
    
    Dictionary<string, int> columns =
      cols.Elements()
      .Where(c => c.Attribute("isactive").Value == "true")
      .ToDictionary(
        c => c.Name.ToString(),
        c => Int32.Parse(c.Attribute("sequence").Value)
      );
