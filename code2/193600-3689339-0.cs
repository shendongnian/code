    Type GetListType(object list)
    {
        Type type = list.GetType();
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            return type.GetGenericArguments()[0];
        else
            throw new ArgumentException("list is not a List<T>", "list");
    }
