        public class DateInfo
        {
            private const long ticksPerDay = 864000000000;
            public bool HasDate { get; private set; }
            public bool HasTime { get; private set; }
            public DateInfo(DateTime date)
            {
                long timeTicks = 0;
                var dayticks = Math.DivRem(date.Ticks, ticksPerDay, out timeTicks);
                HasDate = dayticks > 0;
                HasTime = timeTicks > 0;
            }
            public override string ToString()
            {
                return $"{{{nameof(HasDate)}:{HasDate}, {nameof(HasTime)}:{HasTime}}}";
            }
            private static readonly DateTime testDate = DateTime.Parse("2/2/2 1:11");
            public static DateInfo GetDateInfo(string format)
            {
                var formatted = testDate.ToString(format);
                var dt = DateTime.ParseExact(formatted, format, CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault);
                return new DateInfo(dt);
            }
        }
