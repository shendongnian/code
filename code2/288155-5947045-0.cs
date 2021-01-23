    StringBuilder builder = new StringBuilder();
    
    using (XmlWriter writer = XmlWriter.Create(builder))
    {
        string abc = "hello welcome!!";
    
        writer.WriteStartElement("td");
        writer.WriteAttributeString("style", "padding-left:30px;width:100%");
        {
            writer.WriteStartElement("span");
            writer.WriteAttributeString("id", "AnnMsg");
            writer.WriteAttributeString("target", "_top");
            writer.WriteAttributeString("style", "text-decoration:none;cursor:pointer");
            {
                writer.WriteStartElement("B");
                {
                    writer.WriteStartElement("nobr");
                    {
                        writer.WriteString(abc); // Here's where your variable is rendered as text
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }
