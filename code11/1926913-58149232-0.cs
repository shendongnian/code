    public static class EnumerableExtensions
    {
        /// <summary>Splits a sequence to subsequences according to a specified
        /// predicate.</summary>
        /// <param name="splitPredicate">A function to determine if two consecutive
        /// elements should be split.</param>
        public static IEnumerable<IEnumerable<TSource>> SplitByPredicate<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, bool> splitPredicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (splitPredicate == null)
                throw new ArgumentNullException(nameof(splitPredicate));
            return _(); IEnumerable<IEnumerable<TSource>> _()
            {
                var enumerator = SourceWithBreaks().GetEnumerator();
                using (enumerator)
                {
                    while (enumerator.MoveNext())
                    {
                        yield return GetSubsequence();
                    }
                }
                IEnumerable<(TSource Item, bool IsBreak)> SourceWithBreaks()
                {
                    bool first = true;
                    TSource previous = default;
                    foreach (var item in source)
                    {
                        if (!first && splitPredicate(previous, item))
                        {
                            yield return (default, true);
                        }
                        yield return (item, false);
                        first = false;
                        previous = item;
                    }
                }
                IEnumerable<TSource> GetSubsequence()
                {
                    yield return enumerator.Current.Item;
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.IsBreak) yield break;
                        yield return enumerator.Current.Item;
                    }
                }
            }
        }
    }
