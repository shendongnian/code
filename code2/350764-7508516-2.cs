    var query = numbers.GroupBy(x => x)
                       .Where(g => g.Skip(1).Any())
                       .Select(g => g.Key);
    foreach (int n in query)
    {
        Console.WriteLine(n);
    }
