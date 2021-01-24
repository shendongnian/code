    class Program
    {
        public static bool Equal(DayOfWeek mine, System.DayOfWeek cSharp)
        {
            if (mine == DayOfWeek.Friday && cSharp == System.DayOfWeek.Friday       || 
                mine == DayOfWeek.Monday && cSharp == System.DayOfWeek.Monday       || 
                mine == DayOfWeek.Saturday && cSharp == System.DayOfWeek.Saturday   || 
                mine == DayOfWeek.Sunday && cSharp == System.DayOfWeek.Sunday       || 
                mine == DayOfWeek.Thursday && cSharp == System.DayOfWeek.Thursday   ||
                mine == DayOfWeek.Tuesday && cSharp == System.DayOfWeek.Tuesday     || 
                mine == DayOfWeek.Wednesday && cSharp == System.DayOfWeek.Wednesday)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            DayOfWeek dayOfWeek = DayOfWeek.Tuesday;
            bool areEqual = Equal(dayOfWeek, dateTime.DayOfWeek);
            Console.WriteLine(areEqual);
            Console.ReadKey();
        }
    }
