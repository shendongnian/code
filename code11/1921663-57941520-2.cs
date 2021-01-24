    public class SegmentedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private class CachedComparer : IEqualityComparer<TKey>
        {
            private readonly IEqualityComparer<TKey> _source;
            private int? _cachedHashCode;
            public CachedComparer(IEqualityComparer<TKey> source)
            {
                _source = source ?? EqualityComparer<TKey>.Default;
            }
            public bool Equals(TKey x, TKey y) => _source.Equals(x, y);
            public int GetHashCodeAndCache(TKey key)
            {
                int hashCode = _source.GetHashCode(key);
                _cachedHashCode = hashCode;
                return hashCode;
            }
            public int GetHashCode(TKey key)
            {
                if (_cachedHashCode.HasValue)
                {
                    int hashCode = _cachedHashCode.Value;
                    _cachedHashCode = null; // Use the cache only once
                    return hashCode;
                }
                return _source.GetHashCode(key);
            }
        }
        private readonly CachedComparer _comparer;
        private readonly Dictionary<TKey, TValue>[] _segments;
        public SegmentedDictionary(int segmentsCount, int capacityPerSegment,
            IEqualityComparer<TKey> comparer)
        {
            _comparer = new CachedComparer(comparer);
            _segments = new Dictionary<TKey, TValue>[segmentsCount];
            for (int i = 0; i < segmentsCount; i++)
            {
                _segments[i] = new Dictionary<TKey, TValue>(
                    capacityPerSegment, _comparer);
            }
        }
        private IDictionary<TKey, TValue> GetSegment(TKey key)
        {
            var hashCode = _comparer.GetHashCodeAndCache(key);
            var index = Math.Abs(hashCode) % _segments.Length;
            return _segments[index];
        }
        public int Count => _segments.Sum(d => d.Count);
        public TValue this[TKey key]
        {
            get => GetSegment(key)[key];
            set => GetSegment(key)[key] = value;
        }
        public void Add(TKey key, TValue value) => GetSegment(key).Add(key, value);
        public bool ContainsKey(TKey key) => GetSegment(key).ContainsKey(key);
        public bool TryGetValue(TKey key, out TValue value)
            => GetSegment(key).TryGetValue(key, out value);
        public bool Remove(TKey key) => GetSegment(key).Remove(key);
        public void Clear() => Array.ForEach(_segments, d => d.Clear());
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            => _segments.SelectMany(d => d).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        ICollection<TKey> IDictionary<TKey, TValue>.Keys
            => throw new NotImplementedException();
        ICollection<TValue> IDictionary<TKey, TValue>.Values
            => throw new NotImplementedException();
        void ICollection<KeyValuePair<TKey, TValue>>.Add(
            KeyValuePair<TKey, TValue> item)
            => throw new NotImplementedException();
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(
            KeyValuePair<TKey, TValue> item)
            => throw new NotImplementedException();
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(
            KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            => throw new NotImplementedException();
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(
            KeyValuePair<TKey, TValue> item)
            => throw new NotImplementedException();
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
            => throw new NotImplementedException();
    }
