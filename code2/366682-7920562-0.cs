    using (XmlWriter xml = XmlWriter.Create(ms, settings))
    {
        xml.WriteStartDocument();
        xml.WriteStartElement("List");
        xml.WriteWhitespace("\n");
        xml.WriteStartElement("Employee");
        {
            xml.WriteElementString("First", firstname);
            xml.WriteElementString("Last", lastname);
            xml.WriteWhitespace("\n");
            xml.WriteElementString("Organization", organization);
            xml.WriteElementString("Phone", phone);
        }
        xml.WriteEndElement();
        xml.WriteEndDocument();
        // Flush the writer and rewind to the start of the stream
        xml.Flush();
        ms.Position = 0;
        WebClient client = new WebClient();
        client.UploadFile("http://test.com/test.aspx", ms);
    }
