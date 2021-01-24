    var ans = db.GroupBy(r => r.ID)
                .AsEnumerable()
                .SelectMany(rg => {
                    var rgd = rg.ToDictionary(r => (r.Month, r.Year));
                    var First = rg.Min(r => new DateTime(r.Year, r.Month, 1));
                    var Last = rg.Max(r => new DateTime(r.Year, r.Month, 1));
                    return Enumerable.Range(0, Last.MonthDiff(First) + 1).Select(moffset => {
                        var wd = First.AddMonths(moffset);
                        return rgd.TryGetValue((wd.Month, wd.Year), out var r) ? r : new { ID = rg.Key, wd.Month, wd.Year, Total = 0 };
                    });
                });
