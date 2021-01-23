            static void Main(string[] args)
        {
            var day = Days.Mon;
            Console.WriteLine(day.GetAttribute<DayAttribute>().Name);
            Console.ReadLine();
        }
