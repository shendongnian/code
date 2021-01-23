    using System;
    using System.Xml;
    
    class Program
    {
        static void Main()
        {
            using (var reader = XmlReader.Create("test.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Attribute")
                    {
                        var name = reader.GetAttribute("name");
                        var value = reader.GetAttribute("value");
                        if (name == "abc")
                        {
                            Console.WriteLine("{0}: {1}", name, value);
                        }
                    }
                }
            }
        }
    }
