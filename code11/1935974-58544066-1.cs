    public class TimeConverter : ValueConverter<MinutesAndSecondsTime, long>
    {
        public TimeConverter(ConverterMappingHints mappingHints = null) :
            base(convertToProviderExpression, convertFromProviderExpression,
            mappingHints)
        { }
        private static Expression<Func<MinutesAndSecondsTime, long>> convertToProviderExpression = x => ToTimeLong(x);
        private static Expression<Func<long, MinutesAndSecondsTime>> convertFromProviderExpression = x => ToTimeObject(x);
        private static MinutesAndSecondsTime ToTimeObject(long time)
        {
            return new MinutesAndSecondsTime(time);
        }
        private static long ToTimeLong(MinutesAndSecondsTime time)
        {
            return time.Minutes * 60 + time.Seconds;
        }
    }
