    string xmlString = null;
    using(StringWriter sw = new StringWriter())
    {
        XmlTextWriter writer = new XmlTextWriter(sw);
        writer.Formatting = Formatting.Indented; // if you want it indented
    
        writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
        writer.WriteStartElement("TAG"); //<TAG>
        
        // <SUBTAG>value</SUBTAG>
        writer.WriteStartElement("SUBTAG");
        writer.WriteString("value");
        writer.WriteEndElement(); 
    
        // <SUBTAG attr="hello">world</SUBTAG>
        writer.WriteStartElement("SUBTAG");
        writer.WriteStartAttribute("attr");
        writer.WriteString("hello");
        writer.WriteEndAttribute();
        writer.WriteString("world");
        writer.WriteEndElement(); 
    
        writer.WriteEndElement(); //</TAG>
        writer.WriteEndDocument();
    
        xmlString = sw.ToString();
    }
