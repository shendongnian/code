    Type t = e.EventHandler.GetGenericArguments()[0];
    Delegate handler = (Delegate)
        typeof(EventHandler<>)
        .MakeGenericType(t)
        .GetConstructors()[0]
        .Invoke(new object[]
            {
                backend.Target,
                backend.Method.MethodHandle.GetFunctionPointer()
            });
