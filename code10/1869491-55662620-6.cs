    public static IEnumerable<int> GetDiff(int start, int end)
    {
        while (start < end)
        {
            yield return start;
            start++;
        }
        // yield break; - It is not necessary. It is like `return` which does not return a value.
    }
