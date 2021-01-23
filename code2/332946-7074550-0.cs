    using(var reader = XmlReader.Create(source))
    {
        reader.MoveToContent();
        reader.ReadStartElement(); // <File>
        while(reader.NodeType != XmlNodeType.EndElement)
        {
            Console.WriteLine("subtree:");
            using(var subtree = reader.ReadSubtree())
            {
                while(subtree.Read())
                    Console.WriteLine(subtree.NodeType + ": " + subtree.Name);
            }
            reader.Read();
        }
        reader.ReadEndElement(); // </File>
    }
