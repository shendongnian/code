    public object Get_ListCopy(object original)
    {
        Type elementType = original.GetType().GetGenericArguments()[0];
        Type listType = typeof(List<>).MakeGenericType(elementType);
        object copy = Activator.CreateInstance(listType, new[] { original });
        return copy;
    }
