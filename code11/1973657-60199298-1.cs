    var groupByCount = _context.IP.GroupBy(p => p.Project_Id).Select(g => new { Project_Id = g.Key, Count = g.Count() }).ToList();
    var Project_Ids = groupByCount.Where(p => p.Count <= 2).Select(p => p.Project_Id).ToArray(); 
    var projs  = (from p in _context.Project
                 where Project_Ids.Contains(p.Project_Id)
                 select p).ToList(); 
