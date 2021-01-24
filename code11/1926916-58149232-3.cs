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
            var enumerator = source.GetEnumerator();
            bool finished = false;
            TSource previous = default;
            using (enumerator)
            {
                if (!enumerator.MoveNext()) yield break;
                while (!finished)
                {
                    yield return GetSubsequence().ToArray();
                }
            }
            IEnumerable<TSource> GetSubsequence()
            {
                while (true)
                {
                    yield return enumerator.Current;
                    previous = enumerator.Current;
                    if (!enumerator.MoveNext()) { finished = true; break; }
                    if (splitPredicate(previous, enumerator.Current)) break;
                }
            }
        }
    }
