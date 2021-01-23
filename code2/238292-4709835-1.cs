    public string FormatTimeSpan(TimeSpan ts)
    {
        var sb = new StringBuilder();
        if ((int) ts.TotalHours > 0)
        {
            sb.Append((int) ts.TotalHours);
            sb.Append(":");
        }
        sb.Append(ts.Minutes.ToString("m"));
        sb.Append(":");
        sb.Append(ts.Seconds.ToString("ss"));
        return sb.ToString();
    }
