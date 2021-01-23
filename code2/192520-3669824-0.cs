    public static IEnumerable<object> DyamicOfType<T>(
            this IQueryable<T> input, Type type)
    {
        var ofType = typeof(Queryable).GetMethod("OfType",
                         BindingFlags.Static | BindingFlags.Public);
        var ofTypeT = ofType.MakeGenericMethod(type);
        return (IEnumerable<object>) ofTypeT.Invoke(null, new object[] { input });
    }
    Type type = // ...;
    var entityList = context.Resources.DynamicOfType(type).ToList();
