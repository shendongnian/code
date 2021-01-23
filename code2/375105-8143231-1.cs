    doc.Elements("parent")
                .Select(p =>
                    new XElement("node",
                            new XAttribute("type", p.Name),
                            new XAttribute("label", p.Attribute("name") != null ? p.Attribute("name").Value : ""),
                            p.Elements("child")
                                .Select(c =>
                                        new XElement("node",
                                        new XAttribute("type", c.Name),
                                        new XAttribute("label", c.Attribute("name") != null ? c.Attribute("name").Value : ""),
                                        new XAttribute("years", c.Attribute("age") != null ? c.Attribute("age").Value : ""))
                                    )
                            )
                    );
