        static void Main(string[] args)
        {
            long time = 1310522400000;
            DateTime dt_1970 = new DateTime(1970, 1, 1);
            long tricks_1970 = dt_1970.Ticks;
            long time_tricks = tricks_1970 + time * 10000;
            DateTime dt = new DateTime(time_tricks);
            Console.WriteLine(dt.ToShortDateString()); // result : 7/13
            dt = TimeZoneInfo.ConvertTimeToUtc(dt);
            Console.WriteLine(dt.ToShortDateString());  // result : 7/12
            Console.Read();
        }
