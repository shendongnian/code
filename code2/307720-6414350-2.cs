       var records = (from i in list
                     group i by i.CartID into g
                     select new Item()
                     {
                         RecordID = g.Min(o => o.RecordID),
                         CartID = g.Key,
                         Quantity = g.Sum(o => o.Quantity),
                         ProductID = g.Min(o => o.ProductID)
                     }).ToList();
