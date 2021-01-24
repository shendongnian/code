c#
// This presumes that weeks start with Monday.
// Week 1 is the 1st week of the year with a Thursday in it.
public static int GetIso8601WeekOfYear(DateTime time)
{
    // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
    // be the same week# as whatever Thursday, Friday or Saturday are,
    // and we always get those right
    DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
    if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
    {
        time = time.AddDays(3);
    }
    // Return the week of our adjusted day
    return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
}
Creating a layout renderer which renders 2019.25 etc - see [NLog docs - How to write a custom layout renderer](https://github.com/nlog/nlog/wiki/How-to-write-a-custom-layout-renderer)
c#
// register ${myDateTime}. Register a soon as possible (e.g main(), app_start etc)
LayoutRenderer.Register("myDateTime", logEventInfo => 
    logEventInfo.TimeStamp.Year +"." + GetIso8601WeekOfYear(logEventInfo.TimeStamp));
and now this should work:
    index = "logstash-${myDateTime}"
