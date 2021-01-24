    public class FooComparer : IEqualityComparer<IDictionary<string, object>>
    {
        public bool Equals(IDictionary<string, object> x, IDictionary<string, object> y)
        {
            return x.Keys.All(k => x[k] == y[k]);
        }
        public int GetHashCode(IDictionary<string, object> obj)
        {
            return obj.Aggregate(0, (hash, x) => (x.Value?.GetHashCode() ?? 0) ^ hash);
        }
    }
