    public static class Utility
    {
        /// <summary>
        /// Adds the specified element at the end of the IEnummerable.
        /// </summary>
        /// <typeparam name="T">The type of elements the IEnumerable contans.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="items">The items to be concatenated.</param>
        /// <returns>An IEnumerable, enumerating first the items in the existing enumerable</returns>
        public static IEnumerable<T> ConcatItems<T>(this IEnumerable<T> target, params T[] items) =>
            (target ?? throw new ArgumentException(nameof(target))).Concat(items);
    
        /// <summary>
        /// Inserts the specified element at the start of the IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements the IEnumerable contans.</typeparam>
        /// <param name="target">The IEnummerable.</param>
        /// <param name="items">The items to be concatenated.</param>
        /// <returns>An IEnumerable, enumerating first the target elements, and then the new elements.</returns>
        public static IEnumerable<T> ConcatTo<T>(this IEnumerable<T> target, params T[] items) =>
            items.Concat(target ?? throw new ArgumentException(nameof(target)));
