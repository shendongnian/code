    public static IEnumerable NotOfType<TResult>(this IEnumerable source)
    {
        Type type = typeof(Type);
        foreach (var item in source)
        {
           if (type != item.GetType())
            {
                yield return item;
            }
        }
    }
