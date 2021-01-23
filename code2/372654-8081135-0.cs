    private static readonly DateTime Epoch = new DateTime(1970, 1, 1); 
    public static DateTime Round(this DateTime d, Period p)
    {
        var ts = d - Epoch;
    
        if (p == Period.Hour)
        {
            var hours = (long)ts.TotalHours;
            return Epoch.AddHours(hours);
        }
        else if (p == Period.Days)
        {
            var days = (long)ts.TotalDays;
            return Epoch.AddDays(days);
        }
        // ...
    }
