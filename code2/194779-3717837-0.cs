    public static DateTime AddWorkingDays(DateTime specificDate,
                                          int workingDaysToAdd)
    {
        int completeWeeks = workingDaysToAdd / 5;
        DateTime date = specificDate.AddDays(completeWeeks * 7);
        workingDaysToAdd = workingDaysToAdd % 5;
        for (int i = 0; i < workingDaysToAdd; i++) {
            date = date.AddDays(1);
            while (!IsWeekDay(date)) {
                date = date.AddDays(1);
            }
        }
        return date;
    }
    private static bool IsWeekDay(DateTime date)
    {
        DayOfWeek day = date.DayOfWeek;
        return day != DayOfWeek.Saturday && day != DayOfWeek.Sunday;
    }
