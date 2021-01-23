    public static bool IsContiguous(this IEnumerable<DateTime> dates)
    {
        var startDate = dates.FirstOrDefault();
        if (startDate == null)
            return true;
        //.All() doesn't provide an indexed overload :(
        return dates
            .Select((d, i) => new { Date = d, Index = i })
            .All(d => (d.Date - startDate).Days == d.Index);
    }
