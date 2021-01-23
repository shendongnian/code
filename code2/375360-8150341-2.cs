    IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream
    XmlWriterSettings settings = new XmlWriterSettings();        
    settings.Indent = true;   
    XmlWriter writer = new XmlWriter(isoStream, settings);
            
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 3;
            writer.WriteStartDocument();
            writer.WriteStartElement("elementName");
            writer.WriteAttributeString("attName", "value");
            writer.WriteValue("value of elem");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();            
