    public class Lookup<K, V>
    {
        private readonly Func<K, V> lookup;
        protected Lookup(Func<K, V> lookup)
        {
            this.lookup = lookup;
        }
        public static implicit operator Lookup<K, V>(Dictionary<K, V> dict)
        {
            return new Lookup<K, V>(k => dict[k]);
        }
        public V this[K key]
        {
            get { return lookup(key); }
        }
    }
