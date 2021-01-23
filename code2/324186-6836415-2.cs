    var query = from act in db.Activity
                where act.Id == id
                group act by new { act.Date.Year, act.Date.Month } into g
                select new
                {
                    MonthlyCount = g.Select(act => act.Date.Day).Distinct().Count(),
                    Month = g.Key.Month,
                    Year = g.Key.Year
                };
