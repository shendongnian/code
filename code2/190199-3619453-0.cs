    // Your handful of lists
    IEnumerable<IEnumerable<int>> lists = new[]
        {
            new List<int> { 1, 2, 3 }, 
            new List<int>(), 
            null,
            new List<int> { 2, 3, 4 }
        };
    var intersection = lists
        .Where(c => c != null && c.Count() > 0)
        .Aggregate(lists.First(), (c, d) => c.Intersect(d))
        .ToList();
    foreach (int value in intersection)
    {
        Console.WriteLine(value);
    }
