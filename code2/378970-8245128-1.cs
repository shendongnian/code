    var list = new List<Tuple<char, int>>
    {
        Tuple.Create('a', 6),
        Tuple.Create('b', 7),
        Tuple.Create('c', 1),
        Tuple.Create('a', 5),
        Tuple.Create('a', 3),
        Tuple.Create('b', 4),
        Tuple.Create('g', 2),
    };
    var result = list
        .GroupBy(x => x.Item1)
        .Select(g => new
        {
            Key = g.Key,
            Sum = g.Sum(x => x.Item2)
        })
        .Select(p => new
        {
            Key = p.Key,
            Items = Enumerable.Repeat(10, p.Sum / 10)
                              .Concat(Enumerable.Repeat(p.Sum % 10, 1))
        })
        .SelectMany(p => p.Items.Select(i => Tuple.Create(p.Key, i)))
        .ToList();
