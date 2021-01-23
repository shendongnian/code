    var products = from p in Session.Query<Product>()
                   where // ...some query (snip)
                   select new
                   {
                       Name = p.ProductName,
                       Description = p.ShortDesc,
                       Price = p.Price,
                       Units = p.Quantity
                   };
