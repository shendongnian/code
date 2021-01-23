csharp
internal static class EnumerableExtensions
{
    public static void ForEachLast<T>(this IEnumerable<T> collection, Action<T>? actionExceptLast = null, Action<T>? actionOnLast = null)
    {
        using var enumerator = collection.GetEnumerator();
        var isNotLast = enumerator.MoveNext();
        while (isNotLast)
        {
            var current = enumerator.Current;
            isNotLast = enumerator.MoveNext();
            var action = isNotLast ? actionExceptLast : actionOnLast;
            action?.Invoke(current);
        }
    }
}
This works on any `IEnumerable<T>`. Usage looks like this:
csharp
var items = new[] {1, 2, 3, 4, 5};
items.ForEachLast(i => Console.WriteLine($"{i},"), i => Console.WriteLine(i));
Output looks like:
txt
1,
2,
3,
4,
5
Additionally, you can make this into a `Select` style method. Then, reuse that extension in the `ForEach`. That code looks like this:
csharp
internal static class EnumerableExtensions
{
    public static void ForEachLast<T>(this IEnumerable<T> collection, Action<T>? actionExceptLast = null, Action<T>? actionOnLast = null) =>
        // ReSharper disable once IteratorMethodResultIsIgnored
        collection.SelectLast(i => { actionExceptLast?.Invoke(i); return true; }, i => { actionOnLast?.Invoke(i); return true; }).ToArray();
    public static IEnumerable<TResult> SelectLast<T, TResult>(this IEnumerable<T> collection, Func<T, TResult>? selectorExceptLast = null, Func<T, TResult>? selectorOnLast = null)
    {
        using var enumerator = collection.GetEnumerator();
        var isNotLast = enumerator.MoveNext();
        while (isNotLast)
        {
            var current = enumerator.Current;
            isNotLast = enumerator.MoveNext();
            var selector = isNotLast ? selectorExceptLast : selectorOnLast;
            //https://stackoverflow.com/a/32580613/294804
            if (selector != null)
            {
                yield return selector.Invoke(current);
            }
        }
    }
}
