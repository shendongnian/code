        XmlTextReader reader = new XmlTextReader("test.xml");
        reader.Read();
        Console.WriteLine(reader.NodeType);
        reader.Read();
        Console.WriteLine(reader.NodeType);
        reader.Read();
        Console.WriteLine(reader.NodeType);
        string rs = reader.ReadOuterXml();
