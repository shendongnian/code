    TimeSpan s = DateTime.Now.Subtract(d);
    if (s < TimeSpan.FromDays(1))
    {
     // ...
    }
    else if (s < TimeSpan.FromMonth(1))
    {
     // ...
    }
    // ...
