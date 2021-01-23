        public static bool MoreThanDouble2(string t1, string t2)
        {
            const string format = @"%h\:mm\:ss\:fff";
            long ticks1 = DateTime.ParseExact(t1, format, null,
                 System.Globalization.DateTimeStyles.NoCurrentDateDefault).Ticks,
                 ticks2 = DateTime.ParseExact(t2, format, null,
                 System.Globalization.DateTimeStyles.NoCurrentDateDefault).Ticks;
            return ticks1 - ticks2 > ticks2;
        }
