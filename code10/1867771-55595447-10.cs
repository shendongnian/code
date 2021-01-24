            PasswordSettings settings = new PasswordSettings();
            settings.customerRef = "abc";
            settings.name = "test";
            Logins.Add(settings);
            settings = new PasswordSettings();
            settings.customerRef = "def";
            settings.name = "test1";
            Logins.Add(settings);
            foreach (var login in Logins)
            {
                if (!File.Exists(@"e:\Test.xml"))
                {
                    XDocument doc =
                        new XDocument(
                            new XElement("PasswordSettings",
                                new XElement("Logins",
                                    new XElement("customerRef", login.customerRef),
                                    new XElement("name", login.name)
                                )
                            )
                        );
                    doc.Save(@"e:\Test.xml");
                }
                else
                {
                    XDocument doc = XDocument.Load(@"e:\Test.xml");
                    XElement root = doc.Element("PasswordSettings");
                    IEnumerable<XElement> rows = root.Descendants("Logins");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                        new XElement("Logins",
                            new XElement("customerRef", login.customerRef),
                            new XElement("name", login.name)));
                    doc.Save(@"e:\Test.xml");
                }
            }
            }
