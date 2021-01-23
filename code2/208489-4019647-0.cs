    XDocument xml = XDocument.Parse(xmlString);
      var visitors = (from visitor in xml.Descendants("latestvisitors").Descendants("user")
                                                   select new Visitor()
                                                              {
                                                                  ID = visitor.Element("id").Value,
                                                                  Name = visitor.Element("name").Value,
                                                                  Url = visitor.Element("url").Value,
                                                                  Photo = visitor.Element("photo").Value,
                                                                  Visited = visitor.Element("visited").Value
                                                                  
                                             });
