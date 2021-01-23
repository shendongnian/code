    private IEnumerable<DurDate> GetAllDates(IEnumerable<DurDate> lstDur)
        {
            
            var min = lstDur.Min(x => x.date);
            var max = lstDur.Max(x => x.date);
            var nonexistenceDates = Enumerable.Range(0, (int) max.Subtract(min).TotalDays)
                .Where(
                    x =>
                    !lstDur.Any(p => p.date.DayOfYear == min.AddDays(x).DayOfYear 
                        && p.date.Year == min.AddDays(x).Year))
                .Select(p => new DurDate {date = min.AddDays(p).Date, dure = 0});
            return lstDur.Concat(nonexistenceDates).OrderBy(x=>x.date);
        }
