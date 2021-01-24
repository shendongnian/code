    bool AreDatesClose(DateTime d1, DateTime d2, double minDaysApart, double maxDaysApart)
    {
        var timespan = d1 - d2;
        return timespan.TotalDays >= minDaysApart && timespan.TotalDays <= maxDaysApart;
    }
