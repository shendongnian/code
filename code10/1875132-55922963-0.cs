csharp
/// <summary>
///     Allows you to map and filter in a single operation, by passing in a function that returns
///     a Nullable containing the output that should be included in the final result.
///     Only the values that are not null are included in the resulting sequence.
/// </summary>
public static IEnumerable<T2> Choose<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2?> selector) where T2 : struct
{
    if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
    if (selector is null) throw new ArgumentNullException(nameof(selector));
    // The nested function ensures argument validation happens immediately, rather than
    // being delayed until the caller starts iterating the results.
    IEnumerable<T2> iterator()
    {
        foreach (var item in enumerable)
        {
            var output = selector(item);
            if (output.HasValue)
                yield return output.Value;
        }
    }
    return iterator();
}
