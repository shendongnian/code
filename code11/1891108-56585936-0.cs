    public class ThingWithValues // because I don't know what these things are
    {
        public ThingWithValues(string c1, string c2)
        {
            C1 = c1;
            C2 = c2;
        }
        public string C1 { get; }
        public string C2 { get; }
    }
    public ThingWithValues GetValues() =>
        (DateTime.Now.DayOfWeek == DayOfWeek.Saturday
         || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            ? new ThingWithValues(AllConstants.WeekendConstants.C1, AllConstants.WeekendConstants.C2)
            : new ThingWithValues(AllConstants.WeekdayConstants.C1, AllConstants.WeekdayConstants.C2);
