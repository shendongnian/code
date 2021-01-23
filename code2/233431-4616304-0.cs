    var products =
    (
        from p in products
        where !p.parentID.HasValue
        select new ProductList
        {
            Name = p.Name,
            WarehouseID = (int)(products.Where(p1 => p1 ... ).Select(p1 => (int?)p1.WharehouseID).FirstOrDefault() ?? p.WarehouseID),
            IsInStock = products.Any(p1 => p1 ... )
        }
    )
    .ToArray();
