    public static IEnumerable<T> Last<T>(this IEnumerable<T> enumerable, int nLastElements)
    {
        int count = Math.Min(enumerable.Count(), nLastElements);
        for (int i = enumerable.Count() - 1; i >= enumerable.Count() - count; i--)
        {
            yield return enumerable.ElementAt(i);
        }
    }
