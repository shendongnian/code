    public static string ToStringOverride(this DateTime dateTime, string format)
    {
        // Adjust the "format" as per unique Culture rules not supported by the Framework
        if (CultureInfo.CurrentCulture.LCID == 3084) // 3084 is LCID for fr-ca
        {
            // French Canadians do NOT show 00 for minutes.  ie.  8:00 is shown as "8 h" not "8 h 00"
            if (dateTime.Minute == 0)
            {
                format = format.Replace("mm", string.Empty);
            }
        }
        return dateTime.ToString(format);
    }
