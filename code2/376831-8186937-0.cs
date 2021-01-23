    int i = 0;
    var result = list
        .Select(p => new { Counter = i++, Item = p })
        .Select(p => new { Group = p.Counter / 3, Item = p.Item })
        .GroupBy(p => p.Group)
        .Select(p=>p.Select(q=>q.Item))
        .ToList();
