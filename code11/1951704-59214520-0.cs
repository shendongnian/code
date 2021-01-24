    TimeSpan totalHours = new TimeSpan();
    if (datesList.Any())
    {
    
        DateTime time1 = datesList.First();
        DateTime time2 = datesList.Last();
        totalHours = time1 - time2;
    }
    else
    {
        totalHours = TimeSpan.Zero;
    }
