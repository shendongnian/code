    using System.Xml;
    using System.Xml.Schema;
    
    XmlTextWriter xtwFeed = new XmlTextWriter(Server.MapPath("rss.xml"), Encoding.UTF8);
    
            xtwFeed.WriteStartDocument();
    
            // The mandatory rss tag
    
            xtwFeed.WriteStartElement("rss");
    
            xtwFeed.WriteAttributeString("version", "2.0");
    
            // Write all the tags like above and end all elements
    
            xtwFeed.WriteEndElement();
            xtwFeed.WriteEndDocument();
            xtwFeed.Flush();
            xtwFeed.Close();
