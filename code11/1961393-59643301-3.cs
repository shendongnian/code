    public class DistinctItemComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return y.ToLower().Split().Any(c => x.ToLower().Contains(c));
        }
        public int GetHashCode(string obj)
        {
            return 1;
        }
    }
