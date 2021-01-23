    XDocument doc = XDocument.Load(...);
    var businessObjects = doc.Descendants("Row")
                             .Select(x => new BusinessObject {
                                         Id = (int) x.Element("id"),
                                         Name = (string) x.Element("name")
                                     })
                             .ToList();
