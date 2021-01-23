    public class DoubleDictionary<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private readonly Dictionary<K, Tuple<T, T>> _dictionary = new Dictionary<K, Tuple<T, T>>();
        private readonly Func<bool> _getFirst;
        public DoubleDictionary(Func<bool> GetFirst) {
            _getFirst = GetFirst;
        }
        public void Add(K Key, Tuple<T, T> Value) {
            _dictionary.Add(Key, Value);
        }
        public T this[K index] {
            get {
                Tuple<T, T> pair = _dictionary[index];
                return GetValue(pair);
            }
        }
        private T GetValue(Tuple<T, T> Pair) {
            return _getFirst() ? Pair.Item1 : Pair.Item2;
        }
        public IEnumerable<K> Keys {
            get {
                return _dictionary.Keys;
            }
        }
        public IEnumerable<T> Values {
            get {
                foreach (var pair in _dictionary.Values) {
                    yield return GetValue(pair);
                }
            }
        }
        IEnumerator<KeyValuePair<K, T>> IEnumerable<KeyValuePair<K, T>>.GetEnumerator()  {
            foreach (var pair in _dictionary)  {
                yield return new KeyValuePair<K, T>(pair.Key, GetValue(pair.Value));
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return ((IEnumerable<KeyValuePair<K, T>>)this).GetEnumerator();
        }
    }
