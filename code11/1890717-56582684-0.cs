    public class StringColumnEqualityComparer : IEqualityComparer<List<string>>
    {
        public StringColumnEqualityComparer()
        {
        }
        public bool Equals(List<string> x, List<string> y) {
            bool output = x.SequenceEqual(y);
            return output;
        }
        public int GetHashCode(List<string> obj)
        {
            int output = obj.Aggregate(13, (hash, y) => hash * 7 + y?.GetHashCode() ?? 0);
            return output;
        }
    }
