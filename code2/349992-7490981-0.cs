    public enum Days { Invalid = ~0, Mon, Tues, Wed, Thurs, Fri, Sat, Sun };
    class Program
    {
        static void Main(string[] args)
        {
            int day = 8;
            Days day8 = (Days)day;
            Console.WriteLine("The eighth day is {0}", day8);
            Console.WriteLine("Days contains {0}: {1}", 
                day, Enum.IsDefined(typeof(Days), day));
            Console.WriteLine("Invalid day if {0} doesn't exist: {1}", 
                day, day8.OrDefault(Days.Invalid) );
            Console.WriteLine("Sunday day if {0} doesn't exist: {1}", 
                day, day8.OrDefault(Days.Sun));
            Days day9 = ((Days)9).OrDefault(Days.Wed);
            Console.WriteLine("Day (9) defaulted: {1}", 9, day9);
            Console.ReadLine();
        }
    }
    public static class DaysExtensions
    {
        public static Days OrDefault(this Days d, Days defaultDay) 
        {
            if (Enum.IsDefined(typeof(Days), (Days)d))
            {
                return d;
            }
            return defaultDay;
        }
    }
