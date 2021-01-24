    var ans = src.Select(s => new { s.ID, s.Date1, s.Date2, Diff = (s.Date2.HasValue ? s.Date2.Value-s.Date1 : DateTime.Now.Date-s.Date1).TotalDays+1 })
                 .GroupBy(s => s.ID)
                 .Select(sg => new { ID = sg.Key, sg = sg.Scan(s => new { s.Date1, s.Date2, s.Diff, DiffAccum = s.Diff }, (res, s) => new { s.Date1, s.Date2, s.Diff, DiffAccum = res.DiffAccum + s.Diff }) })
                 .Select(IDsg => new { IDsg.ID, two_year_base = IDsg.sg.FirstOrDefault(s => s.DiffAccum > twoYears) ?? IDsg.sg.Last() })
                 .Select(s => new { s.ID, two_years = s.two_year_base.Date1.AddDays(twoYears-(s.two_year_base.DiffAccum - s.two_year_base.Diff)).Date });
