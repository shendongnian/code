    // Only take the current time once; otherwise you could get into a mess if it
    // changes day between samples.
    DateTime now = DateTime.Now;
    DateTime today = now.Date;
    DateTime start = today.AddHours(startHour);
    DateTime end = today.AddHours(endHour);
    // Cope with a start hour later than an end hour - we just
    // want to invert the normal result.
    bool invertResult = end < start;
    // Now check for the current time within the time period
    bool inRange = (start <= now && now <= end) ^ invertResult;
    if (inRange)
    {
        DoSomething();
    }
