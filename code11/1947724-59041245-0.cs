private static DateTime SemiWeeklyEndDate(DateTime date)
{
    int DaysBetween(DayOfWeek from, DayOfWeek to) => (to - from + 7) % 7;
    var daysToAdd =
        DaysBetween(date.DayOfWeek, DayOfWeek.Saturday) <=
        DaysBetween(DayOfWeek.Tuesday, DayOfWeek.Saturday)
            ? DaysBetween(DayOfWeek.Tuesday, date.DayOfWeek)
            : DaysBetween(DayOfWeek.Friday, date.DayOfWeek);
    return date.AddDays(daysToAdd);
}
