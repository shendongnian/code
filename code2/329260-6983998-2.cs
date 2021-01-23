            public IList<string> Validate(TextReader reader, XmlSchema schema)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(schema);
                settings.ValidationType = ValidationType.Schema;
    
                List<string> errors = new List<string>();
    
                settings.ValidationEventHandler += (sender, e) =>
                {
                    errors.Add(string.Format("Line {0} at position {1}{2}{3}",
                            e.Exception.LineNumber, e.Exception.LinePosition,
                                        Environment.NewLine, e.Message));
                };
    
    
                XmlReader xmlReader = XmlReader.Create(reader, settings);
                while (xmlReader.Read()) { };
    
                return errors;
            } 
