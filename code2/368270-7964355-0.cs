    static class ExtensionsClass
    {
        /// <summary>
        /// Returns the mimimum value within the collection.
        /// </summary>
        static public T Min(this IEnumerable<T> values) where T : IComparable<T>
        {
            T min = values.First();
            foreach(T item in values)
            {
                if (item.CompareTo(min) < 0)
                    min = item;
            }
            return min;
        }
        /// <summary>
        /// Returns the maximum value within the collection.
        /// </summary>
        static public T Max(this IEnumerable<T> values) where T : IComparable<T>
        {
            T max= values.First();
            foreach(T item in values)
            {
                if (item.CompareTo(min) > 0)
                    max= item;
            }
            return max;
        }
    }
