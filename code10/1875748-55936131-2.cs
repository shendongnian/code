    private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
    public static DateTime FromUnixTime(long unixTime)
    {
        return Epoch.AddMilliseconds(unixTime).ToLocalTime();
    }
var expirationDate  = DateUtil.FromUnixTime(yourtime);
