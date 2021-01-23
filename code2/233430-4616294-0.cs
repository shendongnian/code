    var products =
      (
       from p in products
       where !p.parentID.HasValue
       let p1Id = products.Where(p1 => p1 ... ).Select(p1 => p1.WarehouseID).FirstOrDefault()
       select new ProductList
       {
        Name = p.Name,
        WarehouseID = p1Id == 0 ? p.WarehouseID : p1Id,
        IsInStock = p1Id != 0
       }
      
      
      )
      .ToArray();
