    var result = dataBaseList.GroupBy(x => x.Key)
                             .SelectMany(x => x.GroupBy(g => g.CLRExceptionType)
                                               .Select(g => new
                                                            {
                                                                DB = x.Key,
                                                                Exception = g.Key,
                                                                Count = g.Count(), 
                                                                LastOccured = 
                                                                  g.Max(y =>
                                                                        y.EntryDate)
                                                            }))
                             .OrderBy(x=> x.DB)
                             .ThenByDescending(x => x.LastOccured);
