        public static class Utility
    {
    
        public static ILookup<TKey, TElement> EmptyLookup<TKey, TElement>(Func<TKey, TKey> keySelector,
                                                                          Func<TKey, TElement> elementSelector)
        {
            return Enumerable.Empty<TKey>().ToLookup(keySelector, elementSelector);
        }
    
    }
