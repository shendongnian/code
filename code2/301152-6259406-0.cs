    XDocument classes = new XDocument(
                          new XElement("Classes", String.IsNullOrEmpty(classInput) ?
                              null :
                              new XElement("Class",
                                  new XElement("Name", classInput))
                        ));
