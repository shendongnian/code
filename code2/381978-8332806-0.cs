    private static readonly GregorianCalendar DefaultGregorianCalendar = 
        new GregorianCalendar();
    
    private static readonly DateTime UnixEpoch = 
        new DateTime(1970, 1, 1, DefaultGregorianCalendar);
    
    private static long RemoveSeconds(long timestamp)
    {
        // Convert the timestamp into a DateTime.
        var dt = DefaultGregorianCalendar.AddMilliseconds(UnixEpoch, timestamp);
    
        // Get the time in minutes.  The zero has the effect of removing the
        // seconds component.
        var newTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 
            DefaultGregorianCalendar);
    
        // Subtract the epoch from the new time.
        TimeSpan difference = newTime - dt;
    
        // Return the total milliseconds.
        return (long) difference.TotalMilliseconds;
    }
