public static class DateTimeExtensions
{
    public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
    {
        DateTime tmpDate = originalDate;
        while (workDays > 0)
        {
            tmpDate = tmpDate.AddDays(1);
            if (tmpDate.DayOfWeek &lt; DayOfWeek.Saturday && 
                tmpDate.DayOfWeek &gt; DayOfWeek.Sunday &&
                tmpDate.IsHoliday())
                workDays--;
        }
        return tmpDate;
    }
    public static bool IsHoliday(this DateTime originalDate)
    {
        // INSERT YOUR HOlIDAY-CODE HERE!
        return false;
    }
}
