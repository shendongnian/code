    public static class ConcurrentDictionaryEx {
      public static bool Remove<TKey, TValue>(
        this ConcurrentDictionary<TKey, TValue> self, TKey key) {
          return ((IDictionary<TKey, TValue>)self).Remove(key);
      }
    }
