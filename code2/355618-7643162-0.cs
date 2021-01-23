    var query = from product in Products
                from smallpack in product.ItemPacks
                select new {
                    Item = smallpack.Item,
                    Quantity = smallpack.Quantity * product.Quantity
                } into mediumpack
                group mediumpack by mediumpack.Item.ItemCode into bigpack
                select new {
                    Item = bigpack.First().Item, // shared reference
                    Quantity = bigpack.Sum(a => a.Quantity);
                }
    
    query.ToDictionary(...);
