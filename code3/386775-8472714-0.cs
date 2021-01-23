    List<Item> item = xmlDoc.Descendants() 
        .Select(o => new Item {  
            Name = o.Attribute("name") != null ? o.Attribute("name").Value : null,  
            Desc = o.Attribute("desc") != null ? o.Attribute("desc").Value : null,
        }).ToList();  
