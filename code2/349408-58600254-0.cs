csharp
internal static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T>? actionExceptLast = null, Action<T>? actionOnLast = null)
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
items.ForEach(i => Console.WriteLine($"{i},"), i => Console.WriteLine(i));
Output looks like:
txt
1,
2,
3,
4,
5
You could easily make this into a `Select` too (which I will probably do for myself). Overall, an extremely useful extension method.
