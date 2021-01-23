    DateTime dtFrom = new DateTime(2011, 02, 5);
    DateTime dtTo = new DateTime(2011, 02, 9);
    List<DayOfWeek> days = new List<DayOfWeek>();
    while (dtTo != dtFrom)
    {
       dtFrom = dtFrom.AddDays(1);
       days.Add(dtFrom.DayOfWeek);
    }
