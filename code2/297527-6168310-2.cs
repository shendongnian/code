    public sealed class EquatableDictionary<TKey, TValue>
        : IDictionary<TKey, TValue>, IEquatable<ComparableDictionary<TKey, TValue>>
    {
        private readonly Dictionary<TKey, TValue> dictionary;
        public override bool Equals(object other)
        {
            return Equals(other as ComparableDictionary<TKey, TValue>);
        }
        public bool Equals(ComparableDictionary<TKey, TValue> other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (Count != other.Count)
            {
                return false;
            }
            foreach (var pair in this)
            {
                var otherValue;
                if (!other.TryGetValue(pair.Key, out otherValue))
                {
                    return false;
                }
                if (!EqualityComparer<TValue>.Default.Equals(pair.Value,
                                                             otherValue))
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var pair in this)
            {
                int miniHash = 17;
                miniHash = miniHash * 31 + 
                       EqualityComparer<TKey>.Default.GetHashCode(pair.Key);
                miniHash = miniHash * 31 + 
                       EqualityComparer<Value>.Default.GetHashCode(pair.Value);
                hash ^= miniHash;
            }
            return hash;
        }
        // Implementation of IDictionary<,> which just delegates to the dictionary
    }
