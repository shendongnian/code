    ctx.PrintJobs.GroupBy(pj => pj.Department.Name)
                 .ToList()
                 .Select(g => new PrintJobReportItem
                              {
                                  A3SizePercentage = 
                                      g.PercentageOf(p => p.DocumentSize == "a3"),
                                  ...
                              }
