class Program
{
    static void Main()
    {
        var dateList = new List<Item>
        {
            new Item {startDate = DateTime.Now.AddDays(1)},
            new Item {startDate = DateTime.Now.AddDays(-4)},
            new Item {startDate = DateTime.Now.AddDays(-5)}
        };
        if (dateList
            .Pairwise((previous, current) => DateTime.Now > current.startDate && DateTime.Now < previous.startDate)
            .Any(b => b))
        {
            // Do something
        }
    }
}
class Item
{
    public DateTime startDate;
}
static class EnumerableExtensions
{
    public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
        return _(); IEnumerable<TResult> _()
        {
            using var e = source.GetEnumerator();
            if (!e.MoveNext())
                yield break;
            var previous = e.Current;
            while (e.MoveNext())
            {
                yield return resultSelector(previous, e.Current);
                previous = e.Current;
            }
        }
    }
}
  [1]: https://morelinq.github.io/
