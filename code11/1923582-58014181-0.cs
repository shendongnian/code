    DateTime jan1 = new DateTime(DateTime.Today.Year, 1, 1);
    //beware different cultures, see other answers
    DateTime startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
    Dictionary<int, productsDemoObject> allWeeks =
    Enumerable
        .Range(0, 54)
        .Select(i => new {
            weekStart = startOfFirstWeek.AddDays(i * 7)
        })
        .TakeWhile(x => x.weekStart.Year <= jan1.Year)
        .Select(x => new {
            x.weekStart,
            weekFinish = x.weekStart.AddDays(4)
        })
        .SkipWhile(x => x.weekFinish < jan1.AddDays(1))
        .Select((x, i) => new productsDemoObject
        {
            Week = i + 1,
            Month = x.weekStart.Month,
            Amount = 0
        })
        .ToDictionary(x => x.Week, x => x);
    foreach(var week in yas
        .GroupBy(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.PaymentDate ?? DateTime.UtcNow, CalendarWeekRule.FirstDay, DayOfWeek.Monday)))
    {
        allWeeks[week.Key].Amount = week.Sum(x => x.Amount);
    }
