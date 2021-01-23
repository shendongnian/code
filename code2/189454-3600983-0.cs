    public void Linq77()
    {
        List<Product> products = GetProductList();
    
        var categoryCounts =
            from p in products
            group p by p.Category into g
            select new { Category = g.Key, ProductCount = g.Count() };
    
        ObjectDumper.Write(categoryCounts
    }
