    public class Block
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class Presence
    {
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public TimeSpan FlightTime => Arrival - Departure;
    }
    public static class PresenceExtensions
    {
        public static TimeSpan GetTotalFlightTime(this IEnumerable<Presence> presences)
        {
            return new TimeSpan(presences.Sum(r => r.FlightTime.Ticks));
        }
    }
    public static class BlockExtensions
    {
        public static Dictionary<Block, IEnumerable<Presence>> FilterPresences(this IEnumerable<Block> blocks, IEnumerable<Presence> presences)
        {
            Dictionary<Block, IEnumerable<Presence>> result = new Dictionary<Block, IEnumerable<Presence>>();
            foreach (Block block in blocks)
            {
                result.Add(block, presences.Where(p => p.Arrival <= block.End && p.Departure >= block.Start));
            }
            return result;
        }
    }
