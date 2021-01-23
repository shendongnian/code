    public static IList CreateGenericList(Type collectionType)
    {
        var listType = typeof(List<>).MakeGenericType(new[] { collectionType});
        return (IList) Activator.CreateInstance(listType);
    }
