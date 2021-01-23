    TimeSpan earliest = new TimeSpan(20, 0, 0);
    TimeSpan latest = new TimeSpan(23, 59, 59);
    DateTime now = DateTime.Now;
    TimeSpan currentTime = now.TimeOfDay;
    if (currentTime > earliest && currentTime < latest)
    {
        DateTime newDateTime = now.Date.AddDays(1).AddHours(1);
    }
