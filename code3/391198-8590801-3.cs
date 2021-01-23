    public static class MyExtensions
    {
        public static bool TryGetKey<TKey, TValue>(
            this IDictionary<TKey, TValue> dict,
            TValue value,
            out TKey key)
        {
            key = default(TKey);
    
            bool isKeyFound = false;
            foreach (var kvp in dict)
            {
                if (EqualityComparer<TValue>.Default.Equals(kvp.Value, value))
                {
                    isKeyFound = true;
                    key = kvp.Key;
                    break;
                }
            }
            
            return isKeyFound;
        }
    }
