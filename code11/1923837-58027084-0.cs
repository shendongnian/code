    var result = Alldatas
        .AsEnumerable()
        .GroupBy(r => r.TimeStamp.Day)
        .Select(x => new {
            Day = x.Key,
            // Using Aggregate method
            Value = x
                .Select(y => y.Value)
                .Aggregate(new List<double>(), (acc, list) =>
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (acc.Count == i) acc.Add(0);
                        acc[i] += list[i];
                    }
                    return acc;
            }),
            // Pure LINQ, using GroupBy
            Value2 = x
                // Create tuple (index, value) for each double
                .SelectMany(y => y.Value.Select((z, i) => Tuple.Create(i, z)))
                // Group by index
                .GroupBy(y => y.Item1)
                // Sum values within groups
                .Select(y => y.Select(z => z.Item2).Sum())
                // Make list
                .ToList()
        })
        .OrderBy(x => x.Day)
        .ToList();
