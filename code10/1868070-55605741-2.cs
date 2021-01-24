    public static object Add<T,T2>(T a,T2 b)
    {
       var paramA = Expression.Parameter(typeof(T), "a");
       var paramB = Expression.Parameter(typeof(T2), "b");
       var body = Expression.Add(Expression.Convert(paramA, paramB.Type), paramB);
       var add = Expression.Lambda<Func<T, T2, T2>>(body, paramA, paramB).Compile();
       return add(a, b);
    }
