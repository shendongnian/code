        static void Main(string[] args)
        {
            var blahs = new List<Blah>
                            {
                                new Blah(1, 0), new Blah(2, 1),
                                new Blah(3, 2), new Blah(2, 3)
                            };
            blahs.Add(blahs[0]);
            //contains all 4 entries
            var set = new HashSet<Blah>(blahs);
            //contains all 4 entries
            var sortedset = new SortedSet<Blah>(blahs, new BlahComparer());
        }
    }
    public class Blah
    {
        public double Value { get; private set; }
        public Blah(double value, int index)
        {
            Value = value;
            Index = index;
        }
        public int Index { get; private set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    public class BlahComparer : Comparer<Blah>
    {
        public override int Compare(Blah x, Blah y)
        {
            // needs null checks
            var referenceEquals = ReferenceEquals(x, y);
            if (referenceEquals)
            {
                return 0;
            }
            var compare = Comparer<double>.Default.Compare(x.Value, y.Value);
            if (compare == 0)
            {
                compare = Comparer<int>.Default.Compare(x.Index, y.Index);
            }
            return compare;
        }
    }
