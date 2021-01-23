    // allows you to transform every element
    public static List<T> TransformAll<T>(this List<T> list,
                                          Func<T, T> converter)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = converter(list[i]);
        }
        return list;
    }
    // allows you to transform every element based on its index
    public static List<T> TransformAll<T>(this List<T> list,
                                          Func<T, int, T> converter)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = converter(list[i], i);
        }
        return list;
    }
    // allows you to transform chosen elements
    public static List<T> TransformWhere<T>(this List<T> list,
                                            Func<T, bool> predicate,
                                            Func<T, T> converter)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T item = list[i];
            if (predicate(item))
                list[i] = converter(item);
        }
        return list;
    }
    // allows you to transform chosen elements based on its index
    public static List<T> TransformWhere<T>(this List<T> list,
                                            Func<T, int, bool> predicate,
                                            Func<T, int, T> converter)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T item = list[i];
            if (predicate(item, i))
                list[i] = converter(item, i);
        }
        return list;
    }
