    var groupedList = new List<IncidentRiskMatrix>() //change this to the list of IncidentRiskMatrix variable
                      .GroupBy(u => new
                      {
                         Month = u.Date.Month,
                         Year = u.Date.Year,
                      })
                     .Select(grp => new IncidentTrendList
                     {
                        Month = grp.Key.Month,
                        Year = grp.Key.Year,
                        IncidentList = grp.GroupBy(x => x.IncidentName).Select(y => new IncidentList()
                                                      {
                                                         IncidentName = y.Key,
                                                         IncidentTotal = y.Count()
                                                      }
                                                 ).ToList()
                     }).ToList();
