        XmlTextReader reader = new XmlTextReader("test.xml");
        reader.Read();
        Console.WriteLine(reader.NodeType);  // XMLDeclaration
        reader.Read();
        Console.WriteLine(reader.NodeType);  // Whitespace
        reader.Read();
        Console.WriteLine(reader.NodeType);  // Element
        string rs = reader.ReadOuterXml();
