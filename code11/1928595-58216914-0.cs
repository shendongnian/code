    public static IEnumerable<ulong> Combine24BitIntsToUlongs(IList<int> ints)
    {
        for (int i = 0; i < ints.Count / 2; ++i)
        {
            yield return (ulong)(ints[i*2] & 0xFFFFFF) | ((ulong)(ints[i*2+1] & 0xFFFFFF) << 24);
        }
    }
