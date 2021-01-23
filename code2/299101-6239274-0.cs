    var query = db.Table1.GroupJoin(db.Table2,
                    t1 => t1.Id,
                    t2 => t2.t1Id,
                    (t1, joined) => new { t1, joined }
                )
                .SelectMany(r => r.joined.DefaultIfEmpty(), (r, j) => new  
                {
                    r.t1, 
                    j
                })
                .Where(r => r.j == null)
                .Select(r => r.t1);
