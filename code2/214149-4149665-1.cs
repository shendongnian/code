    public static IEnumerable<T> HasNullStringProperties<T>(this IEnumerable<T> items, params string[] propertyNames)
    {
        var properties = items.GetType().GetGenericArguments()[0].GetProperties();
        foreach(var item in items)
            foreach(string propertyName in propertyNames)
            {
                var propertyInfo = properties.SingleOrDefault(p => p.Name.Equals(propertyName));
                if (null != propertyInfo)
                {
                    if (string.IsNullOrEmpty(propertyInfo.GetValue(item, null) as string))
                        yield return item;
                }
            }
    }
