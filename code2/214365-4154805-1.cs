    public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Dictionary<string, string> Attributes { get; set; }
        }
    
        public class DictionarySerializer
        {
            private StringBuilder _sBuilder;
            private XmlWriterSettings _writerSettings;
            private XmlWriter w;
    
            public string WriteXml(Person personObject)
            {
                _sBuilder = new StringBuilder();
                _writerSettings = new XmlWriterSettings();
    
                _writerSettings.Indent = true;
                _writerSettings.OmitXmlDeclaration = true;
                w = XmlWriter.Create(_sBuilder, _writerSettings);
    
                //if you remove person properties any dictionary can be turned into XML.
                w.WriteStartElement("Person");           
                w.WriteElementString("FirstName", personObject.FirstName);
                w.WriteElementString("LastName", personObject.LastName);
                w.WriteStartElement("Attributes");
    
                foreach (var item in personObject.Attributes)
                {
                    w.WriteElementString(item.Key, item.Value);
                }
    
                w.WriteEndElement();
                w.WriteEndElement();
                w.Close();
    
                return _sBuilder.ToString();
            }
        }
