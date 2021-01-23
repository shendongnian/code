    var query = table.ToLookup(o => o.CAT, o => o.Value);
    // specific key: c2
    foreach (var item in query["c2"])
    {
        Console.WriteLine(item);
    }
    
    // all items
    foreach (var item in query)
    {
        Console.WriteLine("Key:" + item.Key);
        foreach (var value in item)
        {
            Console.WriteLine(value);
        }
    }
