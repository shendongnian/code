    //start with some dummy data
    string bigData = "<bigdata><rec id='1'>1234</rec><rec id='2'>2468</rec></bigdata>";
    string criterion = "2";
    string append = "10";
    string newValue = "";
    bool match = false;
    StringBuilder sb = new StringBuilder();
    using (XmlWriter writer = XmlWriter.Create(sb))
    {
        using (XmlReader reader = XmlReader.Create(new StringReader(bigData)))
        {
        while (reader.Read())
        {
        switch (reader.NodeType)
        {
        case XmlNodeType.Element:
            if (reader.LocalName == "rec")
            {
                match = reader.GetAttribute("id").ToString() == criterion;
            }
            writer.WriteStartElement(reader.LocalName);
            writer.WriteAttributes(reader, true);
            if (reader.IsEmptyElement)
            {
                writer.WriteEndElement();
            }
            break;
        case XmlNodeType.Text: // do the append here
            newValue = match ? reader.Value + append : reader.Value;
            writer.WriteString(newValue);
            break;
        //other cases based on node types
        case XmlNodeType.EndElement:
            writer.WriteFullEndElement();
            break;
        }                                                                      
        }
            writer.Flush();
            string x = sb.ToString();//output
        }                         
    }
