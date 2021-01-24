cs
var input = new[] { "a", "b", "c", "d", "e" };
var res = input.Take(1)
               .Concat(input.Skip(1).Take(3).OrderByDescending(e => e))
               .Concat(input.Skip(4));
and you can also make an Extension Method like this
cs
public static class IEnumerableExt
{
    public static IEnumerable<TSource> OrderRangeByDescending<TSource, TKey>(this IEnumerable<TSource> input, Func<TSource, TKey> keySelector, int from, int length)
    {
        return input.Take(from)
                    .Concat(input.Skip(from).Take(length).OrderByDescending(keySelector))
                    .Concat(input.Skip(from + length));
    }
    public static IEnumerable<TSource> OrderRangeBy<TSource, TKey>(this IEnumerable<TSource> input, Func<TSource, TKey> keySelector, int from, int length)
    {
        return input.Take(from)
                    .Concat(input.Skip(from).Take(length).OrderBy(keySelector))
                    .Concat(input.Skip(from + length));
    }
}
cs
var input = new[] { "a", "b", "c", "d", "e" };
var res = input.OrderRangeByDescending(e => e, 1, 3);
