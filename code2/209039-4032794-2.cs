    XmlNode specificNode = document.SelectSingleNode("/NodeName/ChildNodeName");
                        
    if (specificNode != null)
    {
        XmlNodeReader specificNodeReader = new XmlNodeReader(specificNode);
    
        while (specificNodeReader.Read())
        {
            Console.WriteLine(specificNodeReader.Value);
        }
    }
