    public static string SecondsToMinutes(int seconds)
    {
       var ts = new TimeSpan(0, 0, seconds);                
       return new DateTime(ts.Ticks).ToString(seconds >= 3600 ? "hh:mm:ss" : "mm:ss");
    }
