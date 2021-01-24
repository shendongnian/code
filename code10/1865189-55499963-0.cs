    public class CustomEqualityComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.Count == y.Count && 
              x.Select((s, i) => (s: s, i: i)).All(t => t.s.Equals(y[t.i]));
        }
        public int GetHashCode(List<string> obj)
        {
            return obj.Aggregate(293, (c, n) => c ^ n.GetHashCode());
        }
    }
