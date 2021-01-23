    public static Int64 GetJavascriptTimeStamp(this DateTime dt)
    {
        var nineteenseventy = new DateTime(1970, 1, 1);
        var timeElapsed = (dt.ToUniversalTime() - nineteenseventy);
        return (Int64)(timeElapsed.TotalMilliseconds + 0.5);
    }
