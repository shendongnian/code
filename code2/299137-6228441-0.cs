                // New Validation Xml.
                string xsd_file = filename.Substring(0, filename.Length - 3) + "xsd";
                XmlSchema xsd = new XmlSchema();
                xsd.SourceUri = xsd_file;
                
                XmlSchemaSet ss = new XmlSchemaSet();
                ss.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                ss.Add(null, xsd_file);
                if (ss.Count > 0)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;
                    settings.Schemas.Add(ss);
                    settings.Schemas.Compile();
                    settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                    XmlTextReader r = new XmlTextReader(filename2);
                    using (XmlReader reader = XmlReader.Create(r, settings))
                    {
                        while (reader.Read())
                        {
                        }
                    }
                }
