    public static IEnumerable<string> Counter(string digits, int digitCount)
    {
        long max = (long) Math.Pow(digits.Length, digitCount);
        for (long i = 0; i < max; i++)
        {
            yield return ConvertToString(i, digits, digitCount);
        }
    }
