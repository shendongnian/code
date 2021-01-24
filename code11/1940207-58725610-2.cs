    var result2 = list
        .Select((item, index) => list
            .Take(index + 1)
            .Reverse()
            .TakeWhile(x => x.Status == item.Status)
            .Select((x, i) => Tuple.Create(x, index - i))
            .Reverse()
        )
        .GroupBy(x => x.Select(y => y.Item2).Min())
        .Select(x => x.Last())
        .Select(x => new SubItem
        {
            Status = x.First().Item1.Status,
            Value = string.Join("", x.Select(y => y.Item1.Value))
        })
        .ToList();
