    var index = yourArray.MinIndex();
    // ...
    public static class EnumerableExtensions
    {
        public static int MinIndex<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            int minIndex = -1;
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    minIndex = 0;
                    T minValue = enumerator.Current;
                    var comparer = Comparer<T>.Default;
                    int index = 0;
                    while (enumerator.MoveNext())
                    {
                        index++;
                        if (comparer.Compare(enumerator.Current, minValue) < 0)
                            minIndex = index;
                    }
                }
            }
            return minIndex;
        }
    }
