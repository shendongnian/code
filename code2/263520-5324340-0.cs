    public class PredicateEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _predicate;
        public PredicateEqualityComparer(Func<T, T, bool> predicate)
        {
            _predicate = predicate;
        }
        public bool Equals(T x, T y)
        {
            return _predicate(x, y);
        }
        public int GetHashCode(T x)
        {
            return 0;
        }
    }
