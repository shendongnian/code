    List<string> strings = ...
    List<List<string>> groups = strings
        .Select((s, idx) => new { Item = s, Group = idx / 20 })
        .GroupBy(s => s.Group)
        .Select(grp => grp.Select(g => g.Item).ToList())
        .ToList();
