public static class EnumerableExtensions
{
    public static IEnumerable<T> Assert<T>(this IEnumerable<T> input, Func<T, bool> condition)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (condition is null)
            throw new ArgumentNullException(nameof(condition));
        return Impl();
        IEnumerable<T> Impl()
        {
            foreach (var item in input)
            {
                if (!condition(item))
                    throw new AssertionFailedException(...);
                yield return item;
            }
        }
    }
}
