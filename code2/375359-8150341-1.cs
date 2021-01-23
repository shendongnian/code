    XmlWriter writer = new XmlWriter(@"path", Encoding.UTF8);
            
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 3;
            writer.WriteStartDocument();
            writer.WriteStartElement("elementName");
            writer.WriteAttributeString("attName", "value");
            writer.WriteValue("value of elem");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();            
