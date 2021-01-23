    string path = @"E:\tmp\testxml.xml";
    using( var reader = XmlReader.Create(path) )
    {
        bool isOnNode = reader.ReadToDescendant("resource");
        while( isOnNode )
        {
            var element = (XElement)XNode.ReadFrom(reader);
            if( !(reader.NodeType == XmlNodeType.Element && reader.LocalName == "resource") )
                isOnNode = reader.ReadToNextSibling("resource");
        }
    }
