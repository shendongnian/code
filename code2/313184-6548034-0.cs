    var les = new[] { 1, 2, 10, 1, 23, 11, 1, 4, 2, 2 };
    
    var result = les
        .GroupBy(i => i)
        .Select(g => new { Value = g.Key, Count = g.Count() });
    
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
