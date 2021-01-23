            public static bool In<T>(this T t, IEnumerable<T> enumerable)
            {
                foreach (T item in enumerable)
                {
                    if (item.Equals(t))
                    { return true; }
                }
                return false;
            }
    public static bool In<T>(this T t, params T[] items)
            {
                foreach (T item in items)
                {
                    if (item.Equals(t))
                    { return true; }
                }
                return false;
            }
