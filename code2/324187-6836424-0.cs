    var results = db.activities.Where(a => a.id == myID)
                               .GroupBy(a => new 
                                             {
                                                 Month = a.date.Month, 
                                                 Year = a.date.Year
                                             })
                               .Select(g => new
                                            {
                                                Month = g.Key.Month,
                                                Year = g.Key.Year,
                                                Monthly_Count = g.Select(d => d.date.Day)
                                                                 .Distinct()
                                                                 .Count()
                                            })
