    public static IEnumerable Cast(this IEnumerable self, Type innerType)
    {
        var methodInfo = typeof (Enumerable).GetMethod("Cast");
        var genericMethod = methodInfo.MakeGenericMethod(innerType);
        return genericMethod.Invoke(null, new [] {self}) as IEnumerable;
    }
