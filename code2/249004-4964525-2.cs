    public static List<string> GetColumnNames<TEntity>(Table<TEntity> table)
        where TEntity : class
    {
        return GetColumnNames(typeof(TEntity));
    }
    public static List<string> GetColumnNames(DataContext context, string functionName)
    {
        var retType = context.GetType().GetMethod(functionName).ReturnType;
        System.Diagnostics.Debug.Assert(retType.Name == "ISingleResult`1");
        return GetColumnNames(retType.GetGenericArguments().Single());
    }
    public static List<string> GetColumnNames(Type entityType)
    {
        return (from p in entityType.GetProperties()
                let columnAttribute = p.GetCustomAttributes(false)
                                       .OfType<System.Data.Linq.Mapping.ColumnAttribute>()
                                       .SingleOrDefault()
                where columnAttribute != null
                select columnAttribute.Name ?? p.Name)
               .ToList();
    }
    // usage:
    // from a function/procedure name
    var names1 = GetColumnNames(DataContext, "GetTable");
    // or by entity type directly (the return type of the function/procedure)
    var names2 = GetColumnNames(typeof(GetTable));
