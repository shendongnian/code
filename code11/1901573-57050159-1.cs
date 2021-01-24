    // This code was created by Jon Skeet : https://stackoverflow.com/a/43349127/2729609
    // I only changed Action<int> to Func<int, int> and changed the return type.
    private static int InvokeHelper(Func<string[], int> int32Func, object data, Type type)
    {
        // You probably want to validate that it really is a generic method...
        var method = int32Func.Method;
        var genericMethod = method.GetGenericMethodDefinition();
        var concreteMethod = genericMethod.MakeGenericMethod(type);
        return (int)concreteMethod.Invoke(int32Func.Target, new[] { data });
    }
