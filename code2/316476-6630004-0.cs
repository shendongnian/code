    public static object CreateGenericList(Type collectionType)
    {
        var listType = typeof(List<>).MakeGenericType(new System.Type[] { collectionType});
        return Activator.CreateInstance(listType);
    }
