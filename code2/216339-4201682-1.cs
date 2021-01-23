    public IList SomeMethod(Type t)
    { 
        Type listType = typeof(List<>);
        listType = listType.MakeGenericType(new Type[] { t});
        return (IList)Activator.CreateInstance(listType);
    }
