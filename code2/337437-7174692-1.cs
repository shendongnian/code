    var result = Events
        .Select(d => new { DateTime = d, Q = d.Month / 3 })
        .GroupBy(a => new { a.Q, a.DateTime.Year })
        .Select(a => new QuarterInfo
            {
                Events = a.Select(s => s.DateTime),
                QuarterOfYear = a.Key.Q + 1
            });
