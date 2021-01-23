    static T Add<T>(T a, T b) {
        //TODO: re-use delegate!
        // declare the parameters
        ParameterExpression paramA = Expression.Parameter(typeof(T), "a"),
            paramB = Expression.Parameter(typeof(T), "b");
        // add the parameters together
        BinaryExpression body = Expression.Add(paramA, paramB);
        // compile it
        Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
        // call it
        return add(a,b);       
    }
