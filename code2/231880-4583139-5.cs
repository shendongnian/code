    private IEnumerable<DurDate> GetAllDates(IEnumerable<DurDate> lstDur)
        {
            
            var min = lstDur.Min(x => x.date).Date;
            var max = lstDur.Max(x => x.date).Date;
            var nonexistenceDates = Enumerable.Range(0, (int) max.Subtract(min).TotalDays)
                .Where(x =>!lstDur.Any(p => p.date.Date == min.Date.AddDays(x)))
                .Select(p => new DurDate {date = min.Date.AddDays(p), dure = 0});
            return lstDur.Concat(nonexistenceDates).OrderBy(x=>x.date);
        }
