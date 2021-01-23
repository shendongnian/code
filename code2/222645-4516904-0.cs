    public LinkedList<string> AddToLinkedList(XmlReader reader)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            reader.Read();
                        Start:
                            if (reader.NodeType == XmlNodeType.Whitespace || reader.NodeType == XmlNodeType.Element)
                            {
                                reader.Read();
                                goto Start;
                            }
                            else if (reader.NodeType == XmlNodeType.EndElement)
                            {
                                linkedList.AddLast("");
                            }
                            else
                            {
                                linkedList.AddLast(reader.Value);
                            }
                            break;
                    }
                }
            }
