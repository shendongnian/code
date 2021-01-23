    XNamespace ns = NAMESPACE;
    var items = (from c in doc.Descendants(ns +"Item")
        select new Item
        {
           Title = c.Element(ns + "ItemAttributes").Element(ns + "Title").Value,
           SalesRank = c.Element(ns +"SalesRank").Value,
           ASIN = c.Element(ns + "ASIN").Value
        }).ToList<Item>();
          
