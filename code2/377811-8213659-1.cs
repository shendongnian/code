    var query = File
        .ReadLines("input.txt")
        .GroupBy(x => x)
        .Select(g => new { Key = g.Key, Count = g.Count() })
        .OrderByDescending(i => i.Count)
        .Take(20);
    foreach (var item in query)
    {
        Console.WriteLine("{0,5} {1}", item.Count, item.Key);
    }
