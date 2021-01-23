                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = false;
                settings.IgnoreComments = false;
                XmlReaderSettings settings2 = new XmlReaderSettings();
                settings2.IgnoreWhitespace = false;
                settings2.IgnoreComments = false;
                XmlReader xmlreaderOriginalCfg = XmlReader.Create(@"C:\...xml", settings);
                XmlReader xmlreaderVerificationCfg = XmlReader.Create(@"C:\....xml", settings);
                XmlDocument myData = new XmlDocument();
                myData.Load(xmlreaderOriginalCfg);
                XmlDocument myData2 = new XmlDocument();
                myData2.Load(xmlreaderVerificationCfg);
                XmlNode parentNode = myData.SelectSingleNode("/configuration/appSettings");
                foreach (XmlComment comment in myData2.SelectNodes("//comment()"))
                {
                    XmlComment importedCom = myData.CreateComment(comment.Value);
                    parentNode.AppendChild(importedCom);
                    foreach (XmlNode node in myData2.DocumentElement.SelectNodes("/configuration/appSettings/add"))
                    {
                        XmlNode imported = myData.ImportNode(node, true);
                        parentNode.AppendChild(imported);
                    }
                }
                myData.Save(this.pathNew);
