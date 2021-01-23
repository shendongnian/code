    var differences = myList.Pairwise((x, y) => y - x);
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Pairwise<T>(
            this IEnumerable<T> source, Func<T, T, T> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) throw new InvalidOperationException("Sequence cannot be empty.");
                T prev = e.Current;
                if (!e.MoveNext()) throw new InvalidOperationException("Sequence must contain at least two elements.");
                do
                {
                    yield return selector(prev, e.Current);
                    prev = e.Current;
                } while (e.MoveNext());
            }
        }
    }
