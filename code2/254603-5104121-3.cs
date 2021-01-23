    var overlapped = 
        from period in bookedPeriods
        where period.StartDate >= startDate && period.EndDate <= endDate
        select new OverlappedPeriod 
        {
            StartDate = new DateTime(Math.Max(period.StartDate.Ticks, startDate.Ticks)),
            EndDate = new DateTime(Math.Min(period.EndDate.Ticks, endDate.Ticks))
        };
    overlappedPeriods = overlapped.ToList();    
