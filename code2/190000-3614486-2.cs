    DateTime startDate = new DateTime(2010, 9, 1); 
    IEnumerable<DateTime> fourthSundays =
        Enumerable.Range(0, 12)
        .Select(item => startDate.AddMonths(item))
        .Select(currentMonth =>
            Enumerable.Range(22, 7)
            .Select(day => new DateTime(currentMonth.Year, currentMonth.Month, day))
            .Single(date => date.DayOfWeek == DayOfWeek.Sunday)
        );
