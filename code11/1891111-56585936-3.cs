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
Or add the "is weekend" check into another static member within `ThingWithValues`:
    public static ThingWithValues ForDate(DateTime date) =>
        date.DayOfWeek == DayOfWeek.Saturday
         || date.DayOfWeek == DayOfWeek.Sunday
            ? Weekend
            : Weekday;
Now the usage becomes
    var x = ThingWithValues.ForDate(DateTime.Now);
