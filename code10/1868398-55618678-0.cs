    class Program
    {
        static DayOfWeek NextDay(List<DayOfWeek> workingDays, DateTime dateTime)
        {
            var dayOfWeek = (int)dateTime.DayOfWeek;
            dayOfWeek++;
            while (!workingDays.Any(x=> x == (DayOfWeek)dayOfWeek))
            {
                if (dayOfWeek > (int)workingDays.Last())
                    dayOfWeek = (int)workingDays.First();
                else
                    dayOfWeek++;
            }
            return (DayOfWeek)dayOfWeek;
        }
        static void Main(string[] args)
        {
            var workingDays = new List<DayOfWeek>()
            {
                DayOfWeek.Monday,
                DayOfWeek.Thursday,
                DayOfWeek.Saturday
            };
            workingDays.Sort();
            var dayOfWeek = NextDay(workingDays, DateTime.Now);
            Console.WriteLine(dayOfWeek.ToString());
            dayOfWeek = NextDay(workingDays, DateTime.Now.AddDays(1));
            Console.WriteLine(dayOfWeek.ToString());
            dayOfWeek = NextDay(workingDays, DateTime.Now.AddDays(2));
            Console.WriteLine(dayOfWeek.ToString());
            dayOfWeek = NextDay(workingDays, DateTime.Now.AddDays(3));
            Console.WriteLine(dayOfWeek.ToString());
            Console.ReadLine();
        }
    }
}
