    var p = Expression.Parameter(typeof(A), "arg");
    var lambda = Expression.Lambda<Func<A, int>>(
        Expression.Call(
            p,
            typeof(A).GetMethod(
                "SomeMethod",
                BindingFlags.Instance | BindingFlags.NonPublic)),
        p);
    Func<A, int> f = lambda.Compile();
