    while (xmlTextReader.Read())
    {
        switch (xmlTextReader.NodeType)
        {
            case XmlNodeType.XmlDeclaration:
                Console.WriteLine("<?xml version='1.0' encoding='uft-8'?>");
                break;
            case XmlNodeType.Element:
                Console.WriteLine("<{0}>", xmlTextReader.Name);
                break;
            case XmlNodeType.Text:
                Console.WriteLine(xmlTextReader.Value);
                break;            
            case XmlNodeType.EndElement:
                Console.WriteLine("</{0}>", xmlTextReader.Name);
                break;
        }
    }
    // remember to close the reader
    if (xmlTextReader != null)
        xmlTextReader.Close();
