    public class KeyBasedEqualityComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _keyGetter;
        public KeyBasedEqualityComparer(Func<T, TKey> keyGetter)
        {
            _keyGetter = keyGetter;
        }
        public bool Equals(T x, T y)
        {
            return EqualityComparer<TKey>.Default.Equals(_keyGetter(x), _keyGetter(y));
        }
        public int GetHashCode(T obj)
        {
            TKey key = _keyGetter(obj);
            return key == null ? 0 : key.GetHashCode();
        }
    }
