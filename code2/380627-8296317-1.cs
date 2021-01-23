     XDocument xdoc = XDocument.Load(@"path to a file or use text reader");
     var tree = xdoc.Descendants("Object").Skip(1).Select(d =>
                new
                {
                    Type = d.Attribute("type").Value,
                    Properties = d.Descendants("Property")
                }).ToList();
     var props = tree.Select(e =>
        new
        {
            Type = e.Type,
            TabIndex = e.Properties
                        .FirstOrDefault(p => p.Attribute("name").Value == "TabIndex")
                        .Value,
            Size = e.Properties
                    .FirstOrDefault(p => p.Attribute("name").Value == "Size")
                    .Value
        });
