    var query = from s in db.Settings
                group s by new
                {
                  s.Category,
                  s.Group,
                  s.Name,
                  s.Target,
                } into sg
                select new
                {
                  Setting = sg.OrderByDescending(r => r.Modified).FirstOrDefault()
                };
