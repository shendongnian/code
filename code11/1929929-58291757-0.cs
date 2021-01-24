    static DateTime AdjustToValidTime(this DateTime dt, TimeZoneInfo tz)
    {
        if (!tz.IsInvalidTime(dt))
        {
            // The time is already valid
            return dt;
        }
        // Get the adjustment rule that applies
        var rule = tz.GetAdjustmentRules()
            .First(x => x.DateStart <= dt && x.DateEnd > dt);
        // Get the transition gap.  Often will be one hour, but not always
        TimeSpan gap = rule.DaylightDelta;
        // Add the gap to adjust to a valid time
        return dt.Add(gap);
    }
