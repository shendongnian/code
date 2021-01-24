     var x = dbContext.data.GroupBy(c => c.CreationDateTime.Day)
                            .AsEnumerable()
                            .Select(d => new
                            {
                                day = d.Key,
                                hours = d.GroupBy(h => h.CreationDateTime.Hour).Select(h 
                                => new
                                {
                                    hour= h.Key,
                                    count = h.Count()
                                }).ToList()
                            }).ToList();
