    int index = yourArray.MinIndex();
    // ...
    public static class ListExtensions
    {
        public static int MinIndex<T>(this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (source.Count < 1)
                return -1;
            int minIndex = 0;
            var comparer = Comparer<T>.Default;
            for (int i = 1; i < source.Count; i++)
            {
                if (comparer.Compare(source[i], source[minIndex]) < 0)
                    minIndex = i;
            }
            return minIndex;
        }
    }
