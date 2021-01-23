    public static void AddDistinct<T>(this ICollection<T> source, params ICollection<T>[] collections)
    {
        var itemsToAdd = collections.SelectMany(x => x).Where(predicate).Except(source).Distinct().ToArray();
        itemsToAdd.ForEach(source.Add));
    }
    
    public static void AddDistinct<T>(this ICollection<T> source, Func<T, bool> predicate, params ICollection<T>[] collections)
    {
        var itemsToAdd = collections.SelectMany(x => x).Where(predicate).Except(source).Distinct().ToArray();
        itemsToAdd.ForEach(source.Add));
    }
    
    public static void AddDistinct<T>(this ICollection<T> source, params T[] items)
    {
        var itemsToAdd = items.Except(source).Distinct().ToArray();
        itemsToAdd.ForEach(source.Add));
    }
    
    public static void AddDistinct<T>(this ICollection<T> source, Func<T, bool> predicate, params T[] items)
    {
        var itemsToAdd = items.Where(predicate).Except(source).ToArray();
        itemsToAdd.ForEach(source.Add));
    }
