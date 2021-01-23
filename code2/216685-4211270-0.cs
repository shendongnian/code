     // {03:25:42.2400000}
    TimeSpan unSnapped = TimeSpan.FromDays(0.14285);
    
     // {04:00:00}
    TimeSpan snapped = TimeSpan.FromHours(Math.Ceiling(unSnapped.TotalHours));
