    /// <summary>Concatenates elements to a sequence.</summary>
    /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
    /// <param name="target">The sequence to concatenate.</param>
    /// <param name="items">The items to concatenate to the sequence.</param>
    public static IEnumerable<T> ConcatItems<T>(this IEnumerable<T> target, params T[] items)
    {
        if (items == null)
            items = new [] { default(T) };
        return target.Concat(items);
    }
