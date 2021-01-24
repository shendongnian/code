private static DateTime SemiWeeklyEndDate(DateTime date)
{
    int DaysBetween(DayOfWeek from, DayOfWeek to) => (to - from + 7) % 7;
    int DaysToEndOfWeek(DayOfWeek from) => DaysBetween(from, DayOfWeek.Saturday);
    var pastMidWeek = DaysToEndOfWeek(date.DayOfWeek) <= DaysToEndOfWeek(DayOfWeek.Tuesday);
    var daysOffset =
        pastMidWeek
            ? DaysBetween(DayOfWeek.Tuesday, date.DayOfWeek)
            : DaysBetween(DayOfWeek.Friday, date.DayOfWeek);
    return date.AddDays(daysOffset);
}
I think this version conveys the behavior you're after without excessive modulo maths.
