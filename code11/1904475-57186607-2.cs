     while (reader.Read())
            {
                
                switch (reader.NodeType)
                { 
                    case XmlNodeType.Element:
                        Console.Write(" < " + reader.Name);
                        Console.WriteLine(">");
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                Console.WriteLine(" {0}={1}", reader.Name, reader.Value);
                            }
                        }
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
