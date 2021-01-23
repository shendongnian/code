    public static string LastMonthOfQuarterAsString(DateTime date) {
        return String.Format("{0:00}", LastMonthOfQuarter(date));
    }
    private static int LastMonthOfQuarter(DateTime date) {
        int year = date.Year;
        DateTime[] endOfQuarters = new[] {
            new DateTime(year, 3, 31),
            new DateTime(year, 6, 30),
            new DateTime(year, 9, 30),
            new DateTime(year, 12, 31)
        };
        DateTime quarterEndForDate =
            endOfQuarters.Where(d => date <= d)
                         .OrderBy(d => d)
                         .First();
        return quarterEndForDate.Month;                
    }
