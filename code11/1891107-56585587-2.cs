public Type GetConstants() =>
    (DateTime.Now.DayOfWeek == DayOfWeek.Saturday
        || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        ? typeof(AllConstants.WeekendConstants)
        : typeof(AllConstants.WeekdayConstants);
Also on a sidenote. As already mentionend in the comments by BACON, using static classes with constans for this might not be the best solution. From the looks of it I think a dictionary would be best suited. Think something like this: 
public static class WeekConstants
{
    public static Dictionary<string, string> Weekdays { get; } = new Dictionary<string, string>()
    {
        { "C1", "Weekday_C1" },
        { "C2", "Weekday_C2" },
    };
    public static Dictionary<string, string> Weekends { get; } = new Dictionary<string, string>()
    {
        { "C1", "Weekend_C1" },
        { "C2", "Weekend_C2" },
    };
}
In this code I use a readonly property (more [here](https://stackoverflow.com/questions/34743533/automated-property-with-getter-only-can-be-set-why)). This is obviously not a constant but the closest you'll get by using a dictionary.  
It might also be a good idea to use an `Enum` instead of a string as key so you could ask for a weekday using `DayEnum.C1` instead of `"C1"`.
