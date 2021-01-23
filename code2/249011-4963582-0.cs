    public static int CompareStringSequences(
        IEnumerable<string> first, 
        IEnumerable<string> second)
    {
        var x = Enumerable.Zip(first, second, (s1, s2) => s1.CompareTo(s2))
            .FirstOrDefault(i => i != 0);
        return x == 0 ?
                   x1.Length - x2.Length :
                   x;
    }
