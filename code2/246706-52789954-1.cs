    public static class MyExtension
    {
        public static (T Min, T Max) MinMax<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
    
            T min = source.FirstOrDefault();
            T max = source.FirstOrDefault();
    
            foreach (T item in source)
            {
                if (item.CompareTo(min) == -1)
                {
                    min = item;
                }
                if (item.CompareTo(max) == 1)
                {
                    max = item;
                }
            }
    
            return (Min: min, Max: max);
        }
    
    }
