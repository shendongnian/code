            /// <summary>
            /// Removes a given value from the values associated with a key. If the
            /// last value is removed from a key, the key is removed also.
            /// </summary>
            /// <param name="key">A key to remove a value from.</param>
            /// <param name="value">The value to remove.</param>
            /// <returns>True if <paramref name="value"/> was associated with <paramref name="key"/> (and was
            /// therefore removed). False if <paramref name="value"/> was not associated with <paramref name="key"/>.</returns>
            public sealed override bool Remove(TKey key, TValue value)
            {
                KeyAndValues keyValues = new KeyAndValues(key);
                KeyAndValues existing;
    
                if (hash.Find(keyValues, false, out existing)) {
                    // There is an item in the hash table equal to this key. Find the value.
                    int existingCount = existing.Count;
                    int valueHash = Util.GetHashCode(value, valueEqualityComparer);
                    int indexFound = -1;
                    for (int i = 0; i < existingCount; ++i) {
                        if (Util.GetHashCode(existing.Values[i], valueEqualityComparer) == valueHash &&
                            valueEqualityComparer.Equals(existing.Values[i], value)) 
                        {
                            // Found an equal existing value
                            indexFound = i;
                        }
                    }
    
                    if (existingCount == 1) {
                        // Removing the last value. Remove the key.
                        hash.Delete(existing, out keyValues);
                        return true;
                    }
