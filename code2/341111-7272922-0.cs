    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.IndentChars = ("    ");
    string fileName = @"C:\Temp\myXmlfile.xml";
    using (XmlWriter writer = XmlWriter.Create(fileName, settings))
    {			   
        writer.WriteStartElement("items");
  
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            writer.WriteStartElement("item");
            string Key = listBox1.Items[i].ToString().Split('=')[0];
            string Value = listBox1.Items[i].ToString().Split('=')[1];
            writer.WriteElementString("key", Key);
            writer.WriteElementString("value", Value);
            writer.WriteEndElement();
    
        }
        writer.WriteEndElement();
        writer.Flush();
    }
