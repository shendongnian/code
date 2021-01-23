    public static class ConcurrentDictionaryEx {
      public static bool TryRemove<TKey, TValue>(
        this ConcurrentDictionary<TKey, TValue> self, TKey key) {
        TValue ignored;
        return self.TryRemove(key, out ignored);
      }
    }
