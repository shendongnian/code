    public class MultiValueDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private IDictionary<K, HashSet<V>> _dict;
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var entry in _dict)
            {
                var hashSet = entry.Value;
                foreach (var item in hashSet)
                {
                    yield return new KeyValuePair<K, V>(entry.Key, item);
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
