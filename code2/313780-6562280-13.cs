    var productsList = new List<Product>();
    productsList.Add(new Product { Id = 1, Name = "p1", Types = new List<Type>() { new Type() { Id = 1, Name = "ptype1" }, new Type() { Id = 2, Name = "ptype2" } } });
    productsList.Add(new Product { Id = 2, Name = "p2", Types = new List<Type>() { new Type() { Id = 1, Name = "ptype1" } } });
    productsList.Add(new Product { Id = 3, Name = "p3", Types = new List<Type>() { new Type() { Id = 2, Name = "ptype2" } } });
    productsList.Add(new Product { Id = 4, Name = "p4", Types = new List<Type>() { new Type() { Id = 2, Name = "ptype2" }, new Type() { Id = 3, Name = "type3" } } });
    // this is an IEnumerable<Type> (types with the same Id and different name will take only the first)
    var productTypesList = (from p in productsList      // for each product
                            from t in p.Types           // for each type in product
                            group t by t.Id into types  // group em by Id into types
                            select types.First());      // but use only the first (else this would be an IEnumerable<IGrouping<Type>>
    Console.WriteLine("Types:");
    //EDIT: Since Francesca had some complains, and thought having a dictionary from this is difficult, here is a one liner to do that.
    // This can be done by surrounding the query above with parenthesis and adding the ToDictionary() call at the end
    // I prefer not to use a dictionary unless needed and your code seems not to need it since you need to loop on product types, as stated at the end of the question
    // Use this only if you need to store or pass around these values. if you do, you loose potential other properties of your types.
    var prodTypeDict = productTypesList.ToDictionary(v => v.Id, v => v.Name);
    foreach (var p in productTypesList)
    {
        Console.WriteLine(p.Id + " " + p.Name);
    }
    foreach (var type in productTypesList)
    {
        // this is an IEnumerable<Product>
        var products = from p in productsList                   // for each product
                       where p.Types.Any(t => t.Id == type.Id)  // that has this type
                       select p;
        Console.WriteLine("Products of type: " + type.Name);
        foreach (var p in products)
        {
            Console.WriteLine(p.Id + " " + p.Name);
        }
    }
