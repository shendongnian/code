    while (!reader.EOF)
    {
        if (reader.NodeType == XmlNodeType.Element && reader.Name == "entry")
        {
            Console.WriteLine(reader.ReadElementContentAsString());
        }
        else
        {
            reader.Read();
        }
    }
