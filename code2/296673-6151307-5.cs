    // count it
    CountFiles(dest, di, @"*.xls");
    public void CountFiles(TextWriter writer, DirectoryInfo directory, string searchPattern)
    {
        var counter = new FileGroupCounter
        {
            { 5,    Multiplier.K },
            { 10,   Multiplier.K },
            { 20,   Multiplier.K },
            { 100,  Multiplier.K },
            { 1000, Multiplier.K },
            { 5,    Multiplier.M },
            { 10,   Multiplier.M },
            { 20,   Multiplier.M },
            { 50,   Multiplier.M },
            { 100,  Multiplier.M },
        };
        foreach (var file in directory.EnumerateFiles(searchPattern, SearchOption.AllDirectories))
                             // or use GetFiles() if you're not targeting .NET 4.0
        {
            counter.CountFile(file);
        }
        foreach (var result in counter)
        {
            writer.WriteLine("Excel File " + result);
            writer.WriteLine(result.Count);
            writer.WriteLine();
        }
    }
    // and the supporting classes
    public enum Multiplier : long
    {
        K = 1 << 10,
        M = 1 << 20,
        G = 1 << 30,
        T = 1 << 40,
    }
    public class FileGroupCounter : IEnumerable<FileGroupCounter.Result>
    {
        public ReadOnlyCollection<long> Limits { get { return roLimits; } }
        public ReadOnlyCollection<int> Counts { get { return roCounts; } }
        public ReadOnlyCollection<Multiplier> Multipliers { get { return roMultipliers; } }
        public FileGroupCounter()
        {
            limits = new List<long>();
            counts = new List<int>();
            multipliers = new List<Multiplier>();
            roLimits= limits.AsReadOnly();
            roCounts= counts.AsReadOnly();
            roMultipliers= multipliers.AsReadOnly();
        }
        private List<long> limits;
        private List<int> counts;
        private List<Multiplier> multipliers;
        private ReadOnlyCollection<long> roLimits;
        private ReadOnlyCollection<int> roCounts;
        private ReadOnlyCollection<Multiplier> roMultipliers;
        private long CalculateLength(int index)
        {
            return limits[index] * (long)multipliers[index];
        }
        public void Add(long limit, Multiplier multiplier)
        {
            int lastIndex = limits.Count - 1;
            if (lastIndex >= 0 && limit * (long)multiplier <= CalculateLength(lastIndex))
                throw new ArgumentOutOfRangeException("limit, multiplier", "must be added in increasing order");
            limits.Add(limit);
            counts.Add(0);
            multipliers.Add(multiplier);
        }
        public bool CountFile(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException("file");
            for (int i = 0; i < limits.Count; i++)
            {
                if (file.Length <= CalculateLength(i))
                {
                    counts[i]++;
                    return true;
                }
            }
            return false;
        }
        public IEnumerator<Result> GetEnumerator()
        {
            for (int i = 0; i < limits.Count; i++)
            {
                if (counts[i] > 0)
                    yield return new Result(this, i);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public class Result
        {
            public long Limit { get { return counter.limits[index]; } }
            public int Count { get { return counter.counts[index]; } }
            public Multiplier Multiplier { get { return counter.multipliers[index]; } }
            internal Result(FileGroupCounter counter, int index)
            {
                this.counter = counter;
                this.index = index;
            }
            private FileGroupCounter counter;
            private int index;
            public override string ToString()
            {
                if (index > 0)
                    return String.Format("> {0} {1}B and <= {2} {3}B",
                        counter.limits[index - 1], counter.multipliers[index - 1],
                        counter.limits[index], counter.multipliers[index]);
                else
                    return String.Format("<= {0} {1}B",
                        counter.limits[index], counter.multipliers[index]);
            }
        }
    }
