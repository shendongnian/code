    DateTime today = DateTime.Now;
    DateTime startDate = new DateTime(today.Year, today.Month, 1);
    DateTime endDate = startDate.AddMonths(1).AddDays(-1);
    while (startDate <= endDate)
    {
        DayCollection.Add(new Day
        {
            Date = startDate,
            WeekDay = (int)startDate.DayOfWeek,
            WeekNo = startDate.GetWeekOfMonth()
        });
        startDate = startDate.AddDays(1);
    }
