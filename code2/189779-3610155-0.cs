    string[] words = { "A", "B", "C" };
    var query = Products.Where(p => SqlMethods.Like(p.ProductName, "%" + words[0] + "%"));
    foreach (var s in words.Skip(1)) // first item used above so skip it
    {
        query = query.Where(p => SqlMethods.Like(p.ProductName, "%" + s + "%"));
    }
    
    foreach (var item in query)
    {
        Console.WriteLine(item.ProductName);
    }
