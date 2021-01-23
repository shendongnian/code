    public IEnumerable<T> GetNonShared(this IEnumerable<IEnumerable<T>> lists)
    {
        return list.SelectMany(list => list)
                   .GroupBy(x => x)
                   .Where(group => group.Count() < lists.Count)
                   .Select(group => group.Key);
    }
