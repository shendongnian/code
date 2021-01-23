    result = new List<TableClassName>();
    context.DeferredLoadingEnabled = false;
    var t = context.TableClassName.Where(...)
                                  .GroupBy(g => new { g.Date, g.UserID })
                                  .Select(g => (TableClassName)new TableClassNameLocal
                                  {
                                        PK = 1,
                                        Date = Convert.ToDateTime(g.Key),
                                        Counted = g.Sum(x => x.Counted),
                                        Time = g.Sum(x => x.Time),
                                        MaxHR = g.Max(x => x.MaxHR),
                                        PeakCal = g.Max(x => x.PeakCal),
                                        PowerIndex = (g.Sum(x => x.PowerIndex)),
                                        Target = g.Max(x => x.Target),
                                        RepTotal = g.Sum(x => x.RepTotal),
                                        Lifted = g.Sum(x => x.Lifted),
                                        UserID = Convert.ToInt64(g.Key)
                                   }).ToList();
