    var result = list.GroupBy(g => g.C1, (a, b) => new {C1 = a, C2 = b.ToList()})
        .Select(g => new
        {
            g.C1,
            C2 = string.Join(",", g.C2.Select(m => m.C2)),
            C3 = g.C2.Sum(m => m.C3)
        })
        .ToList();
