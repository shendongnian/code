    void anyMethod(object listData, Func<object, string> callback)
    {
        IEnumerable enumerable = listData as IEnumerable;
        if(enumerable == null)
            throw new InvalidOperationException("listData mist be enumerable");
        foreach (object item in enumerable.OfType<object>())
        {
            string value = callback(item);
            doSomething(value)
        }
    };
