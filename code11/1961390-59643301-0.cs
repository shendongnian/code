    public class DistinctItemComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLower().Contains(y.ToLower());
        }
        public int GetHashCode(string obj)
        {
            return 1;
        }
    }
