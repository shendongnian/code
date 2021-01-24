    var results = items.GroupBy(item => item.Item1)
        .Select(grp => new {
            Group = grp,
            Item2Max = grp.Max(item => item.Item2)
        })
        .Select(x => new Tuple<string, int, int>(
            x.Group.Key,
            x.Item2Max,
            x.Group.Where(item => item.Item2 == x.Item2Max).Max(item => item.Item3)
        ));
