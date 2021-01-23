    private static IEnumerable<int> Iterate()
    {
        RuntimeHelpers.PrepareConstrainedRegions();
        try { cerWorked = false; yield return 5; }
        finally { StackOverflow(); }
    }
