    public static int FindFirstIndexGreaterThanOrEqualTo<TElement, TKey>(
                    this IList<TElement> keySortedCollection,
                    TKey key,
                    Func<TElement, TKey> keySelector,
                    IComparer<TKey> keyComparer)
    {
        int begin = 0;
        int end = keySortedCollection.Count;
        while (end > begin)
        {
            int index = (begin + end) / 2;
            TElement el = keySortedCollection[index];
            TKey currElKey = keySelector(el);
            if (keyComparer.Compare(currElKey, key) >= 0)
                end = index;
            else
                begin = index + 1;
        }
        return end;
    }
    
    public static int FindFirstIndexGreaterThanOrEqualTo<TElement, TKey>(
                    this IList<TElement> keySortedCollection,
                    TKey key,
                    Func<TElement, TKey> keySelector)
    {
        return FindFirstIndexGreaterThanOrEqualTo(keySortedCollection,
                                                   key,
                                                   keySelector,
                                                   Comparer<TKey>.Default);
    }
