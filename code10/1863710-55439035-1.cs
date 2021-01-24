    public static IEnumerable<TSource>[] Split<TSource>(this IEnumerable<TSource> source, params int[] indices)
    {
        var parts = new IEnumerable<TSource>[indices.Length + 1];
        var enumerator = source.GetEnumerator();
        int index = 0;
        for (int i = 0; i < indices.Length; i++)
        {
            parts[i] = GetPart(indices[i]);
        }
        parts[indices.Length] = GetPart(Int32.MaxValue);
        return parts;
        IEnumerable<TSource> GetPart(int maxIndexExclusive)
        {
            if (index >= maxIndexExclusive) yield break;
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
                index++;
                if (index >= maxIndexExclusive) yield break;
            }
        }
    }
