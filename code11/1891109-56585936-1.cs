public class ThingWithValues
{
    public ThingWithValues(string c1, string c2)
    {
        C1 = c1;
        C2 = c2;
    }
    public string C1 { get; }
    public string C2 { get; }
    public static ThingWithValues Weekend { get; } =
        new ThingWithValues(AllConstants.WeekendConstants.C1, AllConstants.WeekendConstants.C2);
    public static ThingWithValues Weekday { get; } =
        new ThingWithValues(AllConstants.WeekdayConstants.C1, AllConstants.WeekdayConstants.C2);
}
And then the usage becomes 
    public ThingWithValues GetValues() =>
        (DateTime.Now.DayOfWeek == DayOfWeek.Saturday
         || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            ? ThingWithValues.Weekend
            : ThingWithValues.Weekday;
