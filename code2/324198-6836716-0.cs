    public static class DictionaryHelper
    {
        public static void AddIf<T, U>(this Dictionary<T, U> dict,
                                       T key, 
                                       U value, 
                                       Predicate<T> pred)
        {
            if (pred(key))
                dict.Add(key, value);
        }
    }
