    public static IEnumerable<ReadOnlyMemory<char>> SplitInParts(this String s, Int32 partLength)
    {
        if (s == null)
            throw new ArgumentNullException(nameof(s));
        if (partLength <= 0)
            throw new ArgumentException("Part length has to be positive.", nameof(partLength));
        for (var i = 0; i < s.Length; i += partLength)
            yield return s.AsMemory().Slice(i, Math.Min(partLength, s.Length - i));
    }
