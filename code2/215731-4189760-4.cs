    //ToEnumerable might not be the best name here
    public static IEnumerable<T> ToEnumerable<T>(this T item)
    {
        return Enumerable.Repeat(item,1);
    }
