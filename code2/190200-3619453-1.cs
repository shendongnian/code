    // Your handful of lists
    IEnumerable<IEnumerable<int>> lists = new[]
        {
            new List<int> { 1, 2, 3 }, 
            new List<int>(), 
            null,
            new List<int> { 2, 3, 4 }
        };
    List<int> intersection = lists
        .Where(c => c != null && c.Any())
        .Aggregate(Enumerable.Intersect)
        .ToList();
    foreach (int value in intersection)
    {
        Console.WriteLine(value);
    }
