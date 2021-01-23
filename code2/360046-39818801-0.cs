    /// <summary>
    /// Provides TryGetValue{T} functionality similar to that of <see cref="IDictionary{TKey,TValue}"/>'s implementation.
    /// </summary>
    public static class HashSetExtensions
    {
        private class RetainingHashSetEqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly IEqualityComparer<T> _defaultComparer;
            public RetainingHashSetEqualityComparer(IEqualityComparer<T> defaultComparer)
            {
                _defaultComparer = defaultComparer;
            }
            public T Key { get; private set; }
            public bool Equals(T a, T b)
            {
                if (!_defaultComparer.Equals(a, b))
                {
                    return false;
                }
                Key = a;
                return true;
            }
            public int GetHashCode(T o)
            {
                return _defaultComparer.GetHashCode(o);
            }
        }
        public static bool TryGetValue<T>(this HashSet<T> hashSet, T value, out T original, IEqualityComparer<T> equalityComparer = null)
        {
            // hashSet.Comparer guaranteed not to be null (defaults to EqualityComparer<T>.Default)
            var comparer = new RetainingHashSetEqualityComparer<T>(equalityComparer ?? hashSet.Comparer);
            if (hashSet.Contains(value, comparer))
            {
                original = comparer.Key;
                return true;
            }
            original = default(T);
            return false;
        }
    }
