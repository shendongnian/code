    public enum CountAssertion
    {
        AtLeast,
        Exact,
        AtMost
    }
    
    /// <summary>
    /// Asserts that the number of items in a sequence matching a specified predicate satisfies a specified CountAssertion.
    /// </summary>
    public static bool AssertCount<T>(this IEnumerable<T> source, int countToAssert, CountAssertion assertion, Func<T, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (predicate == null)
            throw new ArgumentNullException("predicate");
        return source.Where(predicate).AssertCount(countToAssert, assertion);
    }
    /// <summary>
    /// Asserts that the number of elements in a sequence satisfies a specified CountAssertion.
    /// </summary>
    public static bool AssertCount<T>(this IEnumerable<T> source, int countToAssert, CountAssertion assertion)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        if (countToAssert < 0)
            throw new ArgumentOutOfRangeException("countToAssert");    
        
        switch (assertion)
        {
            case CountAssertion.AtLeast:
                return AssertCountAtLeast(source, GetFastCount(source), countToAssert);
    
            case CountAssertion.Exact:
                return AssertCountExact(source, GetFastCount(source), countToAssert);
    
            case CountAssertion.AtMost:
                return AssertCountAtMost(source, GetFastCount(source), countToAssert);
    
            default:
                throw new ArgumentException("Unknown CountAssertion.", "assertion");
        }
    
    }
    
    private static int? GetFastCount<T>(IEnumerable<T> source)
    {
        var genericCollection = source as ICollection<T>;
        if (genericCollection != null)
            return genericCollection.Count;
    
        var collection = source as ICollection;
        if (collection != null)
            return collection.Count;
    
        return null;
    }
    
    private static bool AssertCountAtMost<T>(IEnumerable<T> source, int? fastCount, int countToAssert)
    {
        if (fastCount.HasValue)
            return fastCount.Value <= countToAssert;
    
        int countSoFar = 0;
    
        foreach (var item in source)
        {
            if (++countSoFar > countToAssert) return false;
        }
    
        return true;
    }
    
    private static bool AssertCountExact<T>(IEnumerable<T> source, int? fastCount, int countToAssert)
    {
        if (fastCount.HasValue)
            return fastCount.Value == countToAssert;
    
        int countSoFar = 0;
    
        foreach (var item in source)
        {
            if (++countSoFar > countToAssert) return false;
        }
    
        return countSoFar == countToAssert;
    }
    
    private static bool AssertCountAtLeast<T>(IEnumerable<T> source, int? fastCount, int countToAssert)
    {
        if (countToAssert == 0)
            return true;
    
        if (fastCount.HasValue)
            return fastCount.Value >= countToAssert;
    
        int countSoFar = 0;
    
        foreach (var item in source)
        {
            if (++countSoFar >= countToAssert) return true;
        }
    
        return false;
    }
