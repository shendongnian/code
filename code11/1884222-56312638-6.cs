    foreach (var group in groups)
    {
        if (!group.Conditions.Any())
            continue;
        if (group.Conditions.Count == 1)
        {
            var single = group.Conditions.Single();
            query.OrWhereRaw($"([{single.Field}] {single.Operator} ?)", single.Value);
            continue;
        }
        var first = group.Conditions.First();
        var last = group.Conditions.Last();
        var others = group.Conditions.Skip(1).Take(group.Conditions.Count - 2);
        query.OrWhereRaw($"([{first.Field}] {first.Operator} ?", first.Value);
        foreach (var c in others)
            query.OrWhere(c.Field, c.Operator, c.Value);
        query.OrWhereRaw($"[{last.Field}] {last.Operator} ?)", last.Value);
    }
    query.Where("Id", "=", 10);
