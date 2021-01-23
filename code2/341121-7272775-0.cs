    List<Everything> items = ...
    
    var results = items.GroupBy(x => new { x.Product, x.ProductName })
                       .Select(g => new Products() 
                        { 
                           Product = g.Key.Product, 
                           ProductName = g.Key.ProductName 
                        })
                       .ToList();
