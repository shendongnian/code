        var doc = XDocument.Load("Mynamespace.xml");
        var result = doc.Descendants("member");
        foreach (var item in result)
        {
            if(item.Attribute("name").Value== "T:Mynamespace.NamespaceDoc")
            {
                item.Attribute("name").Value= item.Attribute("name").Value.Replace(".NamespaceDoc", " ");
            }
          
        }
        doc.Save("Mynamespace.xml");
