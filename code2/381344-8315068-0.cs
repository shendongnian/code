            var _items = new List<Item>();
            var doc = XDocument.Load(xmlToParse);
            // finds every node of Item
            doc.Descendants("Item").ToList() 
            .ForEach(item =>
            {
               var myItem = new Item(); // your domain type
               {
                  IM = item.Element("IM").Value.ConvertToValueType<bool>(),
                  AL = item.Element("AL").Value.ConvertToValueType<int>(),                 
               };
               _items.Add(myItem);
            });
