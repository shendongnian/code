    List<Product> uniqProductList = new List<Product>() {
                new Product { Name = "GoodOne", Price = 12M },
                new Product { Name = "NiceOne", Price = 12M },
                new Product { Name = "ExpensiveOne", Price = 15M },
                new Product { Name = "BestOne", Price = 9.99M }
    };
    List<Product> dupProductList = new List<Product>() {
                new Product { Name = "GoodOne", Price = 12M },
                new Product { Name = "NiceOne", Price = 12M },
                new Product { Name = "ExpensiveOne", Price = 15M },
    };
    var result = uniqProductList
        .GroupBy(u => u.Price)
        .Select(grp => new { grp.Key, Count = grp.Count(), Items = grp.ToList() })
        .Where(s => s.Count == 1)
        .OrderBy(o=> o.Key)
        .FirstOrDefault();
