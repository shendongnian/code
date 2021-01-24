    public static class Extensions
    {
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> first,
        IEnumerable<T> second, T defaultValue, Func<T, T, T> operation)
        {
            using (var iter1 = first.GetEnumerator())
            using (var iter2 = second.GetEnumerator())
            {
                while (iter1.MoveNext())
                {
                    if (iter2.MoveNext())
                    {
                        yield return operation(iter1.Current, iter2.Current);
                    }
                    else
                    {
                        yield return operation(iter1.Current, defaultValue);
                    }
                }
                while (iter2.MoveNext())
                {
                    yield return operation(defaultValue, iter2.Current);
                }
            }
        }
    }
