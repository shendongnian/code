    public static T CopyTo<T>(this T source, T target) where T : class 
    {
        foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            propertyInfo.SetValue(target, propertyInfo.GetValue(source, null), null);
        }
        return target;
    }
