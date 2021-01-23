    public static string GetSimplestTimeSpan(TimeSpan timeSpan)
    {
        var result = string.Empty;
        if (timeSpan.Days > 0)
        {
            result += string.Format(@"{0:ddd\d}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Hours > 0)
        {
            result += string.Format(@"{0:hh\h}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Minutes > 0)
        {
            result += string.Format(@"{0:mm\m}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Seconds > 0)
        {
            result += string.Format(@"{0:ss\s}", timeSpan).TrimStart('0');
        }
        return result;
    }
