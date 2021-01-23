    string[] words = { "A", "B", "C" };
    var query = dc.Products.AsQueryable(); // gives us an IQueryable<T> to build upon
    foreach (var s in words)
    {
        query = query.Where(p => SqlMethods.Like(p.ProductName, "%" + s + "%"));
    }
    
    foreach (var item in query)
    {
        Console.WriteLine(item.ProductName);
    }
