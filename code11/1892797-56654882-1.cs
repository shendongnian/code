    intents.Select(root => new 
    { 
        Key = root.Item1, 
        Values = root.Item2.Split(',')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList()
            .GroupBy(x => x)
            .Select(g => new 
            { 
                Value = g.Key, 
                Count = g.Count() 
            })
            .OrderByDescending(x => x.Count)
    })
    .ToList()
    .ForEach(x => 
    {
        Console.WriteLine(x.Key);
        x.Values.ForEach(child => Console.WriteLine($"{child.Key}: {child.Value}"))
    });
