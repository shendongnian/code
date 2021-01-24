    var groups = items.GroupBy(p => p.ActivityName)
        .Select(g => new
        {
            ActivityName = g.Key,
            Average = g.Average(t => t.Seconds)
        }).ToList();
