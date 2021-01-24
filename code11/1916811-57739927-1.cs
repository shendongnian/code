public static class LinqExtensions
{
    public static IEnumerable<IEnumerable<int>> GroupSequential (
        this IEnumerable<int> source)
    {
        var previous = source.First();
        var list = new List<int>() { previous };
        foreach (var item in source.Skip(1))
        {
            if (item - previous != 1)
            {
                yield return list;
                list = new List<int>();
            }
            list.Add(item);
            previous = item;
        }
        yield return list;
    }
}
and call it like `list.GroupSequential()`
I think this should work for your needs.
