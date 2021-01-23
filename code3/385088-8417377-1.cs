    XDocument doc = XDocument.Parse(xml);
    IEnumerable<ChemieComponent> result = from c in doc.Descendants("Component")
                                          select new ChemieComponent()
                                          {
                                              Name = (string)c.Attribute("name"),
                                              Id = (string)c.Attribute("id"),
                                              MolarMass = (double)c.Attribute("molarmass")
                                          };
