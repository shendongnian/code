    var items = from r in TestaccountRequest.Queryable
                group r by r.RequestCodeId into g
                select g.ElementAt(0);
    var grouped = from r in items.ToList()
                  group r by new { Year = r.Requested.Year,
                                   Month = r.Requested.Month } into g 
                  select new { g.Key.Year, g.Key.Month, Count = g.Count() };
