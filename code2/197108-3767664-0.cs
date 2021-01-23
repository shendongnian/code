    public static IEnumerable<DateTime> DateRangeToArray(DateTime start,
                                                         DateTime end) {
        DateTime curDate = start;
        while (curDate <= end) {
            yield return curDate;
            curDate = curDate.AddDays(1);
        }
    }
