    public enum BitwiseDayOfWeek
    {
        Sunday	 = 1,
        Monday	 = 2,
        Tuesday	 = 4,
        Wednesday	 = 8,
        Thursday	 = 16,
        Friday	 = 32,
        Saturday	 = 64
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            BitwiseDayOfWeek scheduledDayOfWeek
                = BitwiseDayOfWeek.Saturday | BitwiseDayOfWeek.Sunday;
			
            // turn System.DayOfWeek (DateTime.Now.DayOfWeek) into BitwiseDayOfWeek
            BitwiseDayOfWeek currentDayOfWeek
                = (BitwiseDayOfWeek)Math.Pow(2, (double)DateTime.Now.DayOfWeek);
			
            // test if today is the scheduled day
            if ( (currentDayOfWeek & scheduledDayOfWeek) == currentDayOfWeek )
                Console.WriteLine(currentDayOfWeek);
			
            Console.WriteLine("---------------------");
            Console.ReadLine();
        }
    }
