    public static bool UnsortedSequencesEqual<T>(
        this IEnumerable<T> first,
        IEnumerable<T> second)
    {
        if (first == null)
            throw new ArgumentNullException("first");
        if (second == null)
            throw new ArgumentNullException("second");
        var listA = first.ToList();
        var listB = second.ToList();
        if (listA.Count != listB.Count)
            return false;
        foreach (var i in listA) {
            if (!listB.Remove(i))
                return false;
        }
        // Sanity check.
        if (listB.Count != 0)
            return false;
        return true;
    }
