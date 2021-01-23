    public static IEnumerable<T> HasNullStringProperties<T>(this IEnumerable<T> items, params string[] propertyNames)
    {
        List<T> results = new List<T>();
    
        var properties = items.GetType().GetGenericArguments()[0].GetProperties();
        foreach(string propertyName in propertyNames)
        {
            var propertyInfo = properties.SingleOrDefault(p => p.Name.Equals(propertyName));
            if (null != propertyInfo)
            {
                results.AddRange(items.Where(item => string.IsNullOrEmpty(propertyInfo.GetValue(item, null) as string)).ToList());
            }
        }
    
        return results;
    }
