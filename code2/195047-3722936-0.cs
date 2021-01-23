    public class /* or struct? */ ArbitraryPointInTime
    {
        public int? Year { get; private set; }
        public int? Month { get; private set; }
        public int? Day { get; private set; }
        public int? Hour { get; private set; }
        public int? Minute { get; private set; }
        public int? Second { get; private set; }
        public TimeZone TimeZone { get; private set; }
        // Bunch of constructors that construct a valid structure
        // Prevent nonsensical combinations, e.g. Second specified but Minute null
    }
    public class /* or struct? */ ArbitraryTimePeriod
    {
        public ArbitraryPointInTime? Start { get; private set; }
        public ArbitraryPointInTime? End { get; private set; }
        // Bunch of constructors as above
    }
