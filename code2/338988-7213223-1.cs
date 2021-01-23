    TimeSpan s = DateTime.Now.Subtract(d);
    if (s < TimeSpan.FromDays(1))
    {
     return string.Format("{0:0} hour(s) ago", s.TotalHours);
    }
    else if (s < TimeSpan.FromDays(7))
    {
     return string.Format("{0:0} day(s) ago", s.TotalDays);
    }
    // ...
