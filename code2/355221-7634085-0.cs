    // Optionally another overload with an IComparer<TKey>
    public static TItem ProjectedBinarySearch<TItem, TKey>(
        this IList<TItem> list,
        Func<TItem, TKey> projection)
    {
        // Do the binary search here.
        // TODO: Decide what to do if you can't find the right value... throw
        // an exception? Change the return type to return the *index* instead of the
        // value?
    }
