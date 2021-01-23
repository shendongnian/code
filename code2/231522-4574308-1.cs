    public static IEnumerable<string> Counter(string digits, int digitCount)
    {
        int max = (int) Math.Pow(digits.Length, digitCount);
        return Enumerable.Range(0, max)
                         .Select(i => ConvertToString(i, digits, digitCount));
    }
