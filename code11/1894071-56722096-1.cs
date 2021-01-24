    class Program
    {
        public static bool Equal(DayOfWeek mine, System.DayOfWeek cSharp)
        {
            int mineInt = (int)mine;
            int cSharpInt = (int)cSharp;
            return mineInt == cSharpInt;
        }
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            DayOfWeek dayOfWeek = DayOfWeek.Sunday;
            bool areEqual = Equal(dayOfWeek, dateTime.DayOfWeek);
            Console.WriteLine(areEqual);
            Console.ReadKey();
        }
    }
