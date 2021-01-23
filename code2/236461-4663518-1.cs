        public static bool MoreThanDouble(string t1, string t2)
        {
            const string format = @"%h\:mm\:ss\:fff";
            long ticks1 = TimeSpan.ParseExact(t1, format, null).Ticks,
                 ticks2 = TimeSpan.ParseExact(t2, format, null).Ticks;
            return ticks1 - ticks2 > ticks2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MoreThanDouble("10:11:12:123", "1:23:45:000"));
            Console.WriteLine(MoreThanDouble("10:11:12:123", "9:23:45:000"));
        }
