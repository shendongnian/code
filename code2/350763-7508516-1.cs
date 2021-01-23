    var query = numbers.GroupBy(x => x)
                       .Where(g => g.Take(2).Count() == 2)
                       .Select(g => g.Key);
    foreach (int n in query)
    {
        Console.WriteLine(n);
    }
