    int monthCount = Enumerable.Range(0, 1 + ToDate.Subtract(FromDate).Days)
                        .Select(x => FromDate.AddDays(x))
                        .ToList<DateTime>()
                        .GroupBy(z => new { z.Year, z.Month })
                        .Count();
