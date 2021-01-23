    from d in new[]
    {
        new { Name = "x", Date = new DateTime(2000, 1, 1), Value = 1, },
        new { Name = "x", Date = new DateTime(2001, 1, 1), Value = 2, },
        new { Name = "y", Date = new DateTime(2000, 1, 1), Value = 3, },
    }
        group d by d.Name into g
        let maxDate = g.Max(d => d.Date)
        select new { Name = g.Key, Date = maxDate, Value = g.Single(p => p.Date == maxDate).Value }
