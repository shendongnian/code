    public static class Lookup
    {
        public static ILookup<TKey, TElement> Empty<TKey, TElement>()
            => Enumerable.Empty<TElement>().ToLookup(x => default(TKey));
    }
