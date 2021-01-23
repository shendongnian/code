     List<Setting> list = (from s in db.Settings
                           group s by new
                           {
                             s.Category,
                             s.Group,
                             s.Name,
                             s.Target,
                           } into sg
                           select sg.OrderByDescending(r => r.Modified).FirstOrDefault()
                          ).ToList();
                      
