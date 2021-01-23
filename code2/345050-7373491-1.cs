    var dateFrom = new DateTime(2010, 9, 8); // start of day we care about
    var dateTo = new DateTime(2011, 9, 6).AddDays(1); // end of day we care about
    var query = tgsdbcontext.MemberToMemberships
                            .Where( mm => mm.StartDate > dateFrom && mm.StartDate < dateTo )
                            .GroupBy( mm => mm.Option.Type.Name )
                            .Select( g => new
                             {
                                 Period = g.Key,
                                 Count = g.Count(),
                                 Value = g.Sum( e => e.JoinFee
                                                       + e.InductionFee
                                                       + (e.Option.Period == "year"
                                                            ? EntityFunctions.DiffYears(e.StartDate,e.EndDate) * e.ChargePerPeriod
                                                            : EntityFunctions.DiffMonths(e.StartDate,e.EndDate) * e.ChargePerPeriod))
                              });
