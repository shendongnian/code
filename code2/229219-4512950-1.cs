    XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
    writer.WriteStartDocument();
    writer.WriteStartElement("rss");
    writer.WriteAttributeString("version", "2.0");
    
    writer.WriteStartElement("channel");
    writer.WriteElementString("title", "MyTitle");
    writer.WriteElementString("link", "http://www.mysite.com/");
    if (cache==null)
        FillCache();
    foreach (var kvp in  cache)
    {
        writer.WriteStartElement("item");
        writer.WriteElementString("title", kvp.Key);
        writer.WriteElementString("link", kvp.Value);
        writer.WriteEndElement();
    }
    writer.WriteEndElement();
    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Close();  
