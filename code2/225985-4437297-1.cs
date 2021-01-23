    public static IDictionary<TKey, TValue>
         FindDict<TKey, TValue>(IEnumerable<IDictionary<TKey, TValue>> haystack,
                                TKey needle)
    {
        return haystack.Where(dict => dict.ContainsKey(needle)).FirstOrDefault();
    }
