            using (var stream = new StreamReader("Response.xml"))
            {
                XDocument doc = XDocument.Load(stream);
                var nodes = doc.Elements().Descendants()
                    .Where(x => x.Name == XName.Get("ROW", "http://schemas.datastream.net/MP_functions/MP0118_GetGridHeaderData_001_Result"));
                foreach (var node in nodes)
                {
                    if (node.FirstAttribute != null)
                    {
                        var firstAttribute = node.FirstAttribute;
                        Console.WriteLine($"{firstAttribute.Name.LocalName} - {firstAttribute.Value}");
                        var children = node.Descendants();
                        if (children.Count() > 0)
                        {
                            foreach (var child in children)
                            {
                                Console.WriteLine($"{child.FirstAttribute.Value}:{child.Value}");
                            }
                        }
                        Console.WriteLine("----------------------------------");
                    }
                }
            }
