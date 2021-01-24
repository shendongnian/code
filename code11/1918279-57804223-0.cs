    var statsPerfLog = _context
        .PerfLog
        // group logs by the tuple [CompanyName, ServerName]
        // and select the `MemoryAvailableMBytes` from every log
        .GroupBy(l => new {l.CompanyName, l.ServerName}, l => l.MemoryAvailableMBytes)
        .Select(group => new ServerStats
        {
            CompanyName = group.Key.CompanyName,
            ServerName = group.Key.ServerName,
            Average = group.Average(),
            Minimum = group.Min(),
            Maximum = group.Max()
        })
        .ToList();
