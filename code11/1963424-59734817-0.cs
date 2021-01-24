    private static DateTime Stime = DateTime.Now.Date.AddHours(18);
    private static DateTime Etime = DateTime.Now.Date.AddDays(1).AddHours(7);
    
    ...
    
    if((dateTime_Time> Stime) && (dateTime_Time < Etime))
    {
    ...
    }
