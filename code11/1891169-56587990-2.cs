    var result = flattenedBuilds
        .GroupBy(b => new { b.Repository, b.Branch })
        .Select(g => new
        {
           g.Key.Repository,
           g.Key.Branch,
           LastBuild = g.OrderByDescending(v => v.Version).FirstOrDefault()?.Version
        });
