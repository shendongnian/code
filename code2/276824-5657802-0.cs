    XmlTextReader xml = new XmlTextReader("response.xml");
    while (xml.Read())
    {
        switch (xml.NodeType)
        {
            case XmlNodeType.Element:
                {
                    if (xml.Name == "RESPONSE") Console.WriteLine("Response: ");
                    if (xml.Name == "FNAME")
                    {
                        Console.Write("First Name: ");
                    }
                    if (xml.Name == "LNAME")
                    {
                        Console.Write("Last Name: ");
                    }
                    if (xml.Name == "ADDRESS") Console.WriteLine("Address: ");
                    if (xml.Name == "LINE1")
                    {
                        Console.Write("Line 1: ");
                    }
                    if (xml.Name == "LINE2")
                    {
                        Console.Write("Line 2: ");
                    }
                }
                break;
            case XmlNodeType.Text:
                {
                    Console.WriteLine(xml.Value);
                }
                break;
            default: break;
        }
    }
    Console.ReadKey();
