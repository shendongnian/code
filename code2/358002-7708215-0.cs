        public static void Add<K1, K2, V>(
                this IDictionary<K1, Dictionary<K2, V>> @this,
                K1 key1,
                K2 key2,
                V value)
        {
            if (@this == null) { throw new ArgumentNullException("@this"); }
            if (key1 == null) { throw new ArgumentNullException("key1"); }
            if (key2 == null) { throw new ArgumentNullException("key2"); }
            if (!@this.ContainsKey(key1))
            {
                @this[key1] = new Dictionary<K2, V>();
            }
            @this[key1][key2] = value;
        }
