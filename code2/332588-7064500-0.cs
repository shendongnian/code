    public static IEnumerable<IEnumerable<int>> GetConsecutiveCollections(this IEnumerable<int> source)
    {
        var list = new List<int>();
        var start = source.Min() - 1;
        foreach (var i in source)
        {
            if (i == start + 1)
            {
                list.Add(i);
                start = i;
            }
            else
            {
                var result = list.ToList();
                list.Clear();
                list.Add(i);
                start = i;
                yield return result;
            }
        }
        yield return list;
    }
