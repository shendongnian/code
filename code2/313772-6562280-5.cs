    var productsList = new List<Product>();
    productsList.Add(new Product { Id = 1, Name = "p1", Types = new List<Type>() { new Type() { Id = 1, Name = "ptype1" }, new Type() { Id = 2, Name = "ptype2" } } });
    productsList.Add(new Product { Id = 2, Name = "p2", Types = new List<Type>() { new Type() { Id = 1, Name = "ptype1" } } });
    productsList.Add(new Product { Id = 3, Name = "p3", Types = new List<Type>() { new Type() { Id = 2, Name = "ptype2" } } });
    productsList.Add(new Product { Id = 4, Name = "p4", Types = new List<Type>() { new Type() { Id = 2, Name = "ptype2" }, new Type() { Id = 3, Name = "type3" } } });
    // this is an IEnumerable<Type>
    var productTypesList = (from p in productsList
                            from t in p.Types
                            group t by t.Id into types
                            select types.First());
    Console.WriteLine("Types:");
    foreach (var p in productTypesList)
    {
        Console.WriteLine(p.Id + " " + p.Name);
    }
    foreach (var type in productTypesList)
    {
        // this is an IEnumerable<Product>
        var products = from p in productsList
                       where p.Types.Any(t => t.Id == type.Id)
                       select p;
        Console.WriteLine("Products of type: " + type.Name);
        foreach (var p in products)
        {
            Console.WriteLine(p.Id + " " + p.Name);
        }
    }
