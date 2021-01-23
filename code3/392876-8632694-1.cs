    string text1 = /* get value of textbox */;
    string text2 = /* get value of textbox */;
    string text3 = /* get value of textbox */;
    
    // Set indent=true so resulting file is more 'human-readable'
    XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
    // Put writer in using scope; after end of scope, file is automatically saved.
    using (XmlWriter writer = XmlTextWriter.Create("file.xml", settings))
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("root");
        writer.WriteElementString("text1", text1);
        writer.WriteElementString("text2", text2);
        writer.WriteElementString("text3", text3);
        writer.WriteEndElement();
    }
