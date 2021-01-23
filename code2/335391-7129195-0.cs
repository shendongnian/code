        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now.AddDays(200);
            while (begin <= end)
            {
                if (begin.DayOfWeek == DayOfWeek.Friday)
                    Console.WriteLine(begin.ToLongDateString());
                begin = begin.AddDays(1);
            }
            Console.ReadKey();
        }
