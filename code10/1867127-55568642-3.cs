    var breaknameduplicate = xdoc.Descendants("sec").Descendants("break")
        .GroupBy(n => n.Attribute("name").Value.Trim()).ToList()
        .Where(g => g.Count() > 1)
        .Select(g => new { Name = g.Key, count = g.Count(), 
            Sections = g.Select(e => e.Ancestors("sec")
                                     ?.Elements("title")
                                     ?.FirstOrDefault()
                                     ?.Value)
                              .ToList() 
                          })
        .ToList();
