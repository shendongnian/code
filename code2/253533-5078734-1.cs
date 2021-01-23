    var comparer = new ProjectionEqualityComparer<A, B>(a => a.B);
    // ...
    public sealed class ProjectionEqualityComparer<TSource, TKey>
        : EqualityComparer<TSource>
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IEqualityComparer<TKey> _keyComparer;
        
        public ProjectionEqualityComparer(Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            _keySelector = keySelector;
            _keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
        }
        public override bool Equals(TSource x, TSource y)
        {
            if (x == null)
                return (y == null);
            if (y == null)
                return false;
            return _keyComparer.Equals(_keySelector(x), _keySelector(y));
        }
        public override int GetHashCode(TSource obj)
        {
            if (obj == null)
               throw new ArgumentNullException("obj");
            return _keyComparer.GetHashCode(_keySelector(obj));
        }
    }
