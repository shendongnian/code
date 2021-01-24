    public static class ListExt {
        public static int FindNearestIndex<T>(this List<T> l, T possibleKey) {
            var keyIndex = l.BinarySearch(possibleKey);
            if (keyIndex < 0) {
                keyIndex = ~keyIndex;
                if (keyIndex == l.Count)
                    keyIndex = l.Count - 1;
            }
            return keyIndex;
        }
    }
    
    public static class IEnumerableExt {
        public static SortedList<TKey, TValue> ToSortedList<T, TKey, TValue>(this IEnumerable<T> src, Func<T, TKey> keySelector, Func<T, TValue> valueSelector) =>
            new SortedList<TKey, TValue>(src.ToDictionary(keySelector, valueSelector));    
    }
