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
                if (!File.Exists("e:\\Test.xml"))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create("E:\\Test.xml", xmlWriterSettings))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("PasswordSettings");
                        xmlWriter.WriteStartElement("Logins");
                        xmlWriter.WriteElementString("customerRef", login.customerRef);
                        xmlWriter.WriteElementString("name", login.name);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }
                else
                {
                    XDocument xDocument = XDocument.Load("e:\\Test.xml");
                    XElement root = xDocument.Element("PasswordSettings");
                    IEnumerable<XElement> rows = root.Descendants("Logins");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                        new XElement("Logins",
                            new XElement("customerRef", login.customerRef),
                            new XElement("name", login.name)));
                    xDocument.Save("e:\\Test.xml");
                }
            }
