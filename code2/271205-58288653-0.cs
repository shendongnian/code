    // WIN32 FILETIME is a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
    // While the unix timestamp represents the seconds since January 1, 1970 (UTC).
    private static long Win32FileTimeToUnixTimestamp(long fileTime)
    {
        //return fileTime / 10000L - 11644473600000L;
        return DateTimeOffset.FromFileTime(fileTime).ToUnixTimeSeconds();
    }
    
    // The GeneralizedTime follows ASN.1 format, something like: 20190903130100.0Z and 20190903160100.0+0300
    private static long GeneralizedTimeToUnixTimestamp(string generalizedTime)
    {
        var formats = new string[] { "yyyyMMddHHmmss.fZ", "yyyyMMddHHmmss.fzzz" };
        return DateTimeOffset.ParseExact(generalizedTime, formats, System.Globalization.CultureInfo.InvariantCulture).ToUnixTimeSeconds();
    }
