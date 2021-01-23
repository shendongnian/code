    var doc = // XDocument.Load() or XDocument.Parse() ...
    var functions =
        from f in doc.Root.Elements()
        select new
        {
            // ...
            Parameters = f.Elements("parameters").Elements().Count() == 0
                ? null
                : (
                    from p in f.Elements("parameters").Elements()
                    select new {
                        DataType = p.Attribute("type"),
                        Name = p.Attribute("name"),
                        Occurence = p.Attribute("occurence")
                  })
                  .ToList()
            // ...
        };
