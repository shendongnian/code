    DateTime StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(5).AddMonths(2);
    var allYearMonthes = Enumerable.Range(StartDate.Year, EndDate.Year - StartDate.Year -1)
                                   .Select(o => Enumerable.Range(1, 12)
                                   .Select(q => new { Year = o, Month = q }))
                                   .SelectMany(o => o);
    
    var enumerable = allYearMonthes.Except(list.Select(o => new { o.Year, o.Month }));
    var dateTimes = enumerable.Select(o => new DateTime(o.Year, o.Month, 1));
