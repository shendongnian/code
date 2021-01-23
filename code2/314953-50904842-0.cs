     string xml = File.ReadAllText(@"C:\xml.txt");
                XDocument wapProvisioningDoc = XDocument.Parse(xml);
                foreach(var ele in wapProvisioningDoc.Elements().Elements("characteristic"))//characteristic
                {
                    var attribute = ele.Attribute("target");
                    if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
                    {
                        attribute.Remove();
                    }
                }
