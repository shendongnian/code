    public static IEnumerable<T> DistinctByPrevious<T>(List<T> source)
    {
        if (source != null && source.Any())
        {
            T prev = source.First();
            yield return prev;
            foreach (T item in source.Skip(1))
            {
                if (!EqualityComparer<T>.Default.Equals(item, prev))
                {
                    yield return item;
                }
                prev = item;
            }
        }
    }
