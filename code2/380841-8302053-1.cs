    var results = new Dictionary<string, List<Product>>();
    foreach (var p in products)
    {
        if (p.value > 100.0)
        {
            List<Product> productsByGroup;
 
            if (!results.TryGetValue(p.Category, out productsByGroup))
            {
                productsByGroup = new List<Product>();
                results.Add(p.Category, productsByGroup);
            }
            productsByGroup.Add(p);
        }
    }
