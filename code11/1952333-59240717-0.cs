C#
public sealed class BreakingEnumerable<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> _query;
    private readonly Predicate<T> _continuePredicate;
    public BreakingEnumerable(IEnumerable<T> query, Predicate<T> predicate)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
        _continuePredicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _query)
        {
            if (_continuePredicate(item))
            {
                yield return item;
            }
            else
            {
                yield break;
            }
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
Of course, you'd want to make this part of your query, so you'd probably want an extension methods class to convert a query *to* this custom enumerable:
C#
public static class BreakingEnumerableExtensions {
    public static BreakingEnumerable<T> WithTerminationClause<T>(
        this IEnumerable<T> query,
        Predicate<T> breakCondition)
    {
        return new BreakingEnumerable<T>(query, breakCondition);
    }
}
And here's the actual usage:
C#
static void Main(string[] args)
{
    var enumerable = Enumerable.Range(1, 100);
    var array = enumerable.WithTerminationClause(i => i > 100).ToArray();
    Console.WriteLine($"Enumerable with termination clause array length: {array.Length}");
    array = enumerable.Where(i => i < 20).WithTerminationClause(i => i % 2 == 0)
        .ToArray();
    Console.WriteLine($"Enumerable with termination clause length: {array.Length}");
}
Which produces the result:
Enumerable with termination clause array length: 0
Enumerable with termination clause length: 9
This can be chained to produce some minor optimizations:
C#
// Outputs: `Query results: [100, 200, 300]`
var enumerable = Enumerable.Range(1, 100);
var sub = enumerable.WithTerminationClause(i => i <= 3)
    .Select(i => i * 100);
Console.WriteLine("Query results: [{0}]", string.Join(", ", sub));
The only "hitch" is you would never want to use this unless you could guarantee some form of ordering: all numbers appear in an ordered sequence, for example. If you didn't enforce this guarantee, then you could possibly produce incorrect results from your program.
Hope this helps!
