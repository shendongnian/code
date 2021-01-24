    var groupByCount = _context.IP.GroupBy(p => p.Project_Id).Select(g => new { Project_Id = g.Key, Count = g.Count() }).ToList();
    var projs  = (from p in _context.Project
                 join pDetail in groupByCount on p.Project_Id equals pDetail.Project_Id
                 where  pDetail.Count <= 2
                 select p).ToList(); 
