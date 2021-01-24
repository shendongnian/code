        static void Main(string[] args)
        {
            List<LocalTime> localTimes = new List<LocalTime>();
            localTimes.Add(new LocalTime(23, 57, 25));
            localTimes.Add(new LocalTime(23, 58, 25));
            localTimes.Add(new LocalTime(23, 59, 25));
            localTimes.Add(new LocalTime(11, 57, 25));
            localTimes.Add(new LocalTime(12, 58, 25));
            localTimes.Add(new LocalTime(15, 59, 25));
            IEnumerable<LocalTime> locals = localTimes.Select(CreateRounder(new TimeSpan(0, 3, 0)));
            foreach (LocalTime t in locals)
            {
                Console.WriteLine(t.Hour + ":" + t.Minute + ":" + t.Second);
            }
    
            List<LocalDateTime> localDateTimes = new List<LocalDateTime>();
            localDateTimes.Add(new LocalDateTime(2019, 5, 20, 23, 58, 25));
            localDateTimes.Add(new LocalDateTime(2019, 5, 20, 23, 59, 25));
            localDateTimes.Add(new LocalDateTime(2019, 5, 20, 11, 42, 25));
            localDateTimes.Add(new LocalDateTime(2019, 5, 20, 5, 58, 25));
    
            IEnumerable<LocalDateTime> ldt = localDateTimes.Select(CreateDateTimeRounder(new TimeSpan(0, 3, 0)));
    
            foreach (LocalDateTime t in ldt)
            {
                Console.WriteLine(t.Year + "-" + t.Month + "-" + t.Day + " " + t.Hour + ":" + t.Minute + ":" + t.Second);
            }
            Console.ReadLine();
        }
    
        public static Func<LocalTime, LocalTime> CreateRounder(TimeSpan d) =>
    input =>
    {
        var delta = input.TickOfDay % d.Ticks;
        bool roundUp = delta > d.Ticks / 2;
    
        if (roundUp)
        {
            var rUpDelta = (d.Ticks - (input.TickOfDay % d.Ticks)) % d.Ticks;
            return input.PlusTicks(rUpDelta);
        }
    
        return input.PlusTicks(-1 * delta);
    };
        public static Func<LocalDateTime, LocalDateTime> CreateDateTimeRounder(TimeSpan d) =>
    input =>
    {
        var delta = input.TickOfDay % d.Ticks;
        bool roundUp = delta > d.Ticks / 2;
        if (roundUp)
        {
            var rUpDelta = (d.Ticks - (input.TickOfDay % d.Ticks)) % d.Ticks;
            return input.PlusTicks(rUpDelta);
        }
        return input.PlusTicks(-1 * delta);
    };
