    XDocument xdoc = XDocument.Load(@"..\..\XMLFile1.xml");
    var data = 
    xdoc.Root.Elements("Component")
             .SelectMany(e => new
                              {
                                type = e.Attribute("type").Value, 
                                paramValues = e.Elements()
                                               .Select(x => new KeyValuePair<string,
                                                                             string>
                                                                  (x.Name.LocalName, 
                                                                   x.Value)),
                                paramType = e.Elements()
                                             .Select(x => x.Attributes().First()
                                                                         .Value)
                              });
    List<string> comNames = data.Select(x => x.type).ToList();
    List<string> paramTypes = data.Select(x => x.paramType).ToList();
    Dictionary<string, string> paramValues = data.Select(x => x.paramValues)
                                                 .ToDictionary(x => x.Key, 
                                                               x => x.Value);
