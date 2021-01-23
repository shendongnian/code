    var first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    List<DateTime> weekends = new List<DateTime>();
    for(int i=0; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
    {
        var nextDay = first.AddDays(i);
        if (nextDay.DayOfWeek == DayOfWeek.Saturday || nextDay.DayOfWeek == DayOfWeek.Sunday)
        {
            weekends.Add(nextDay);
        }
    }
