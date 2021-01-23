    public static class EnumerableExceptions
    {
        public static IEnumerable<TItem> Catch<TItem, TEx>(
            this IEnumerable<TItem> source, 
            Action<TEx> handler) where TEx : Exception
        {
            using (var enumerator = source.GetEnumerator())
            {
                for (; ; )
                {
                    try
                    {
                        if (!enumerator.MoveNext())
                            yield break;
                    }
                    catch (TEx x)
                    {
                        handler(x);
                        yield break;
                    }
                    yield return enumerator.Current;
                }
            }
        }
    }
