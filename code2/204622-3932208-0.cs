    public bool IsGenericList(Type source)
    {
        return source.IsGenericType &&
               source.GetGenericTypeDefinition() == typeof(List<>);
    }
