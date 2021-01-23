    processCollection(methodInfo, type2);
    ...
    protected void processCollection(MethodInfo method, Type type2)
    {
        var type1 = typeof(MyDataClass);
        object output = method.MakeGenericMethod(type1, type2).Invoke(null, new object[] { collection });
    }
