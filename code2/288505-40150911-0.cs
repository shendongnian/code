    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static long GetCurrentUnixTimestampMillis()
    {
        DateTime localDateTime, univDateTime;
        localDateTime = DateTime.Now;          
        univDateTime = localDateTime.ToUniversalTime();
        return (long)(univDateTime - UnixEpoch).TotalMilliseconds;
    } 
