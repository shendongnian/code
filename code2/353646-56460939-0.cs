    Response.Clear();
    Response.ContentType = "application/rss+xml";
    XmlTextWriter writer = new XmlTextWriter(@"E:\product.xml", 
    System.Text.Encoding.UTF8);
    writer.WriteStartDocument(true);
    writer.WriteStartElement("rss");
    writer.WriteAttributeString("version", "2.0");
    writer.WriteStartElement("produts");
    writer.Formatting = Formatting.Indented;
    writer.Indentation = 2; 
    
    createNode("1", "Product 1", "1000", writer);
    createNode("2", "Product 2", "2000", writer);
    createNode("3", "Product 3", "3000", writer);
    createNode("4", "Product 4", "4000", writer);
    writer.WriteEndElement();
    writer.WriteEndElement();
    writer.Close();
