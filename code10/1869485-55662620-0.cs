    public static IEnumerable<int> GetDiff(int start, int end)
    {
        while (start < end)
        {
            yield return start;
            start++;
        }
    }
