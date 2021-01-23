    public static IEnumerable<T> Intercept<T>(this IEnumerable<T> values, Action<T> each)
    {
        foreach (var item in values)
        {
            each(item);
            yield return item;
        }
    }
    public static IEnumerable<T> Intercept<T>(this IEnumerable<T> values, Action<T, int> each)
    {
        var index = 0;
        foreach (var item in values)
        {
            each(item, index++);
            yield return item;
        }
    }
    // ...
    a.Intercept(x => { Console.WriteLine(x); }).Count();
