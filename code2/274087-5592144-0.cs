    var list = Enumerable.Range(1, 190);
    var sublists = list
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / 50)
        .Select(x => x.Select(v => v.Value).ToList())
        .ToArray();
