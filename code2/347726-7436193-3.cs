    public IEnumerable<T> GetNonShared(this IEnumerable<IEnumerable<T>> lists)
    {
        return list.SelectMany(list => list.Distinct())
                   .GroupBy(x => x)
                   .Where(group => group.Count() < list.Count)
                   .Select(group => group.Key);
    }
