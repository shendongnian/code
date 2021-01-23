    public string PrettyFormatTimeSpan(TimeSpan span)
    {
        if (span.Days > 0)
             return string.Format("{0} days, {1} hours, {2} minutes", span.Days, span.Hours, span.Minutes);
        if (span.Hours > 0)
             return string.Format("{0} hours, {1} minutes", span.Hours, span.Minutes);
        return  string.Format("{0} minutes", span.Minutes);
    }
