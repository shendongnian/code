class Program
    {
        static DateTime NextDay(List<DayOfWeek> workingDays, DateTime dateTime)
        {
            var result = dateTime;
            var dayOfWeek = (int)dateTime.DayOfWeek;
            dayOfWeek++;
            result = result.AddDays(1);
            while (!workingDays.Any(x=> x == (DayOfWeek)dayOfWeek))
            {
                if (dayOfWeek > (int)workingDays.Last())
                {
                    var delta = ((int)workingDays.First() + 7) - dayOfWeek;
                    dayOfWeek = (int)workingDays.First();
                    result = result.AddDays(delta);
                    
                }
                else
                {
                    dayOfWeek++;
                    result = result.AddDays(1);
                }
            }
            return result;
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
