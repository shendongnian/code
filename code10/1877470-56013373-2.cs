    var results = allData.GroupBy(d => new {d.City1, d.City2})
        .Select(group => new Data("Prev", group.Key.City1, group.Key.City2,
            (int) Math.Ceiling(group.Average(g => g.Value))))
        .OrderBy(d => d.City1)
        .ThenBy(d => d.City2);
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
