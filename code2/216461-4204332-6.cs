    int index = yourArray.MinIndex();
    // ...
    public static class EnumerableExtensions
    {
        public static int MinIndex<T>(
            this IEnumerable<T> source, IComparer<T> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (comparer == null)
                comparer = Comparer<T>.Default;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return -1;    // or maybe throw InvalidOperationException
                int minIndex = 0;
                T minValue = enumerator.Current;
                int index = 0;
                while (enumerator.MoveNext())
                {
                    index++;
                    if (comparer.Compare(enumerator.Current, minValue) < 0)
                    {
                        minIndex = index;
                        minValue = enumerator.Current;
                    }
                }
                return minIndex;
            }
        }
    }
