    Product[] result = products
      .Select(product => new Product() {
         ProductName = bunchChar
           .Aggregate(product.ProductName, (name, bunch) => name.Replace(bunch, ""))),
         ProductType = bunchChar
           .Aggregate(product.ProductType, (name, bunch) => name.Replace(bunch, "")))
       }
      .ToList();
