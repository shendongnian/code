    public static class Ex
    {
    //Use var list = _context.MyDbSet("ConsoleAppEF.Student").ToList();
    public static IQueryable MySet(this SchoolContext context, string typeName)
    {
        var T = Type.GetType(typeName);
        // Get the generic type definition
        MethodInfo method = typeof(SchoolContext).GetMethod("MySet", BindingFlags.Public | BindingFlags.Instance);
    
        // Build a method with the specific type argument you're interested in
        method = method.MakeGenericMethod(T);
    
        return method.Invoke(context, null) as IQueryable;
    }
    
    public static IQueryable<T> Set<T>(this SchoolContext context)
    {
        // Get the generic type definition 
        MethodInfo method = typeof(SchoolContext).GetMethod(nameof(SchoolContext.Set), BindingFlags.Public | BindingFlags.Instance);
    
        // Build a method with the specific type argument you're interested in 
        method = method.MakeGenericMethod(typeof(T));
    
        return method.Invoke(context, null) as IQueryable<T>;
    }
    
    public static IList ToList1(this IQueryable query)
    {
        var genericToList = typeof(Enumerable).GetMethod("ToList")
            .MakeGenericMethod(new Type[] { query.ElementType });
        return (IList)genericToList.Invoke(null, new[] { query });
    }
    }
