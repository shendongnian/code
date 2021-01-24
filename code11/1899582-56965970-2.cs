    public static class LinqExtension
    {
        public static IEnumerable<IEnumerable<TSource>> JoinBy<TSource, TOrderKey, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TOrderKey> orderBy,
            Func<TSource, TKey> keySelector,
            Func<TKey, TKey, bool> join)
        {
            var results = new List<List<TSource>>();
            var orderedSource = new List<TSource>(source).OrderBy(orderBy).ToArray();
            if (orderedSource.Length > 0)
            {
                var group = new List<TSource> { orderedSource[0] };
                results.Add(group);
                if (orderedSource.Length > 1)
                {
                    for (int i = 1; i < orderedSource.Length; i++)
                    {
                        var lag = orderedSource[i - 1];
                        var current = orderedSource[i];
                        if (join(keySelector(lag), keySelector(current)))
                        {
                            group.Add(current);
                        }
                        else
                        {
                            group = new List<TSource> { current };
                            results.Add(group);
                        }
                    }
                }
            }
            return results;
        }
    }
