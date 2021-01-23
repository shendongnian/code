    public static class EnumerableExtensions
    {
        public static IEnumerable<Tuple<T, T>> Pairs<T>(this IEnumerable<T> seq)
        {
            using (var enumerator = seq.GetEnumerator())
            {
                enumerator.MoveNext();
                var prior = enumerator.Current;
    
                while (enumerator.MoveNext())
                {
                    yield return Tuple.Create(prior, enumerator.Current);
                    prior = enumerator.Current;
                }
            }
        }
    }
