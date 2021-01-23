      var items = (from c in doc.Descendants("Item")
                   select new Item
                   {
                     Title = c.Element("ItemAttributes").Element("Title").Value,
                     SaleRank = c.Element("SalesRank").Value,
                     ASIN = c.Element("ASIN").Value
                   }).ToList<Item>();
