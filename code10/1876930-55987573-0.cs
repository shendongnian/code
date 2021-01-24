    var placementsWithDuplicates = from p in _context.Placements.Where(m => m.User_id == m.Definition_id)
    select new {
        Id = p.Id,
        User = p.User_id,
        Defi = p.Definition_id,
    };
    // this is same as the top one
    var placementsWithDuplicates = from p in _context.Placements where p.User_id == p.Definition_id
    select new {
        Id = p.Id,
        User = p.User_id,
        Defi = p.Definition_id,
    };
    foreach (var p in placementsWithDuplicates)
    {
        issues.Add(new IssueModel()
            {
                Type = "Praxe ID[" + p.Id + "]",
                Name = "User id [" + p.User + "], Definition id [" + p.Defi + "]",
                Detail = "So user shouldnt have data for more definitons!"
            });
    };
