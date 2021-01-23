    var startDate = DateTime.Now;
    var first = new DateTime(startDate.Year, startDate.Month, 1);
    List<DateTime> weekends = new List<DateTime>();
    for (int i = 0; i <= DateTime.DaysInMonth(startDate.Year, startDate.Month); i++)
    {
        var nextDay = first.AddDays(i);
        if (nextDay.DayOfWeek == DayOfWeek.Saturday || nextDay.DayOfWeek == DayOfWeek.Sunday)
        {
            weekends.Add(nextDay);
        }
    }
