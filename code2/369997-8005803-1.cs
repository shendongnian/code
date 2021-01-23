    public static class ListExtensions
    {
        public static IEnumerable<T> LastItems<T>(this IList<T> list, int numberOfItems) //Can also handle arrays
        {
            for (int index = Math.Max(list.Count - numberOfItems, 0); index < list.Count; index++)
                yield return list[index];
        }
    }
