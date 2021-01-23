    public static IEnumerable<TResult> SelectHierarchy<TResult>(this IEnumerable<TResult> source, Func<TResult, IEnumerable<TResult>> collectionSelector, Func<TResult, bool> predicate)
    {
        if (source == null)
        {
            yield break;
        }
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
            var childResults = SelectHierarchy(collectionSelector(item), collectionSelector, predicate);
            foreach (var childItem in childResults)
            {
                yield return childItem;
            }
        }
    }
