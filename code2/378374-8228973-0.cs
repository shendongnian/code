    public static bool In<T>(this T item, params T[] list)
    {
        return list.Contains(item);
    }
    ...
    if (!x.In(2,3,61,71))
    ...
