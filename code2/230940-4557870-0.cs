    // Only take the current time once; otherwise you could get into a mess if it
    // changes day between samples.
    DateTime now = DateTime.Now;
    DateTime today = now.Date;
    DateTime start = today.AddHours(startHour);
    DateTime end = today.AddHours(endHour);
    // Cope with a start hour later than an end hour
    if (end < start)
    {
        end = end.AddHours(24);
    }
    // Now check for the current time within the time period
    if (start <= now && now <= end)
    {
        DoSomething();
    }
