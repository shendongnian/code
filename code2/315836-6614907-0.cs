    var doc = XDocument.Load("DataStructure.xml");
    var cols = doc.XPathSelectElements("/datastructure/" + sPageName + "/columns");
    
    Dictionary<string, int> columns =
      cols.Elements()
      .Where(c => !c.Attributes().Any(a => a.Name.ToString() == "isactive" && a.Value != "true"))
      .ToDictionary(
        c => c.Name.ToString(),
        c => Int32.Parse(c.Attributes().Where(a => a.Name.ToString() == "sequence").Value)
      );
