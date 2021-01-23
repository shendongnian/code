    public static IEnumerable<T> Where(this IEnumerable<T> source, Funct<T, bool> predicate)
    {
       foreach (T item in source)
           if (predicate(item))
               yield return item;
    }
