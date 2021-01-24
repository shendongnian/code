    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            var t = x.Intersect(y).Count();
            return t == x.Length;
        }
        public int GetHashCode(string obj)
        {
            return obj.Length;
        }
    }
