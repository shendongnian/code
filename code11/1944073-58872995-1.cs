    public class Block
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan FlightTime => End - Start;
    }
    public static class BlockExtensions
    {
        public static TimeSpan GetTotalFlightTime(this IEnumerable<Block> blocks)
        {
            return new TimeSpan(blocks.Sum(r => r.FlightTime.Ticks));
        }
    }
