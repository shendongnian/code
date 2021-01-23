    MyTable
        .Where(t => t.ProcessedOn >= start && t.ProcessedOn <= stop)
        .GroupBy(t => t.ActionID)
        .Select(g => new {
            Action = g.Key,
            LastStatus =
                g.Where(a => a.ProcessedOn == g.Max(a2 => a2.ProcessedOn) )
                    .Single().Status
        })
        .ToList();
