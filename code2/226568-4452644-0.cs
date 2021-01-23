    public static Type GetListType(object someList)
    {
        if (someList == null)
            throw new ArgumentNullException("someList");
    
        var type = someList.GetType();
    
        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(List<>))
            throw new ArgumentException("someList", "Type must be List<>, but was " + type.FullName);
    
        return type.GetGenericArguments()[0];
    }
