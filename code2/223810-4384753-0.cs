    public static bool IsBeforeStartOfCurrentMonth(this DateTime date) {
        DateTime now = DateTime.Now;
        DateTime startOfCurrentMonth = new DateTime(now.Year, now.Month, 1);
        return date < startOfCurrentMonth;
    }
