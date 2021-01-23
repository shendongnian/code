    public static class EnumerableExtensions
    {
        private static IEnumerable<T> Concat<T>(this IEnumerable<T> list, T item)
        {
            foreach (var element in list)
            {
                yield return element;
            }
            yield return item;
        }
    }
