     XDocument xDoc=XDocument.Load(@"C:\File.xml");            
    Process(xDoc.Root);
    
    
    public static void Process(XElement element)
            {
                if (element.HasElements)
                {
                    Console.WriteLine("<" + element.Name.LocalName + ">");
                    foreach (XElement child in element.Elements())
                    {
                        Process(child);
                    }
                    Console.WriteLine("<" + element.Name.LocalName + ">");
                }
                else
                {
                    Console.WriteLine("<" + element.Name.LocalName);
                    if(element.HasAttributes)
                    {
                        foreach (XAttribute attr in element.Attributes())
                        {
                            Console.WriteLine(attr.Name +"="+attr.Value);
                        }
                    }
                    Console.WriteLine(">" + element.Value + "</" + element.Name.LocalName + ">");  
                }
            }
