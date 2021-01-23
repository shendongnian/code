    public class BpmRange
    {
        static uint[] thresholds = new uint[] { 0, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280, 300, uint.MaxValue };
        public static BpmRange GetRange(uint bpm)
        {
            var index = Enumerable.Range(1, thresholds.Length - 1).First(i => bpm < thresholds[i]);
            return new BpmRange(thresholds[index - 1], thresholds[index]);
        }
        private BpmRange(uint lowerInclusive, uint upperExclusive) { range = Tuple.Create(lowerInclusive, upperExclusive); }
        private Tuple<uint, uint> range;
        public uint LowerInclusive { get { return range.Item1; } }
        public uint UpperExclusive { get { return range.Item2; } }
        public override bool Equals(object obj) { var asRange = obj as BpmRange; return asRange != null && this.range.Equals(asRange.range); }
        public override int GetHashCode() { return range.GetHashCode(); }
        public override string ToString() { return String.Format("[{0}, {1})", LowerInclusive, UpperExclusive); }
    }
    List<Simfile> simfiles = ...;
    var query = from sim in simfiles
                select new
                {
                    Simfile = sim,
                    ByRange = from chart in sim.Notecharts
                              group chart by BpmRange.GetRange(chart.BPM)
                };
