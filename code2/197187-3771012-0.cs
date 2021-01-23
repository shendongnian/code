    public IQueryable<TResult> GetColumn<TResult>(string tableName, string columnName)
    {
        // Get the table, e.g. for "Customers" get db.Customers
        var table = db.GetType().GetField(tableName).GetValue(db);
        // Find the specific type parameter (the T in IQueryable<T>)
        var iqueryableT = table.GetType().FindInterfaces((ty, obj) => ty.IsGenericType && ty.GetGenericTypeDefinition() == typeof(IQueryable<>), null).FirstOrDefault();
        var type = iqueryableT.GetGenericArguments()[0];
        // Construct a query that retrieves the relevant column
        var param = Expression.Parameter(type);
        var prop = Expression.Property(param, columnName);
        var expression = Expression.Lambda(prop, param);
        // Call Queryable.Select() with the appropriate parameters
        // Notice there are two Select methods, need to get the right one...
        return (IQueryable<TResult>) typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(meth => meth.Name == "Select")
            .Select(meth => meth.MakeGenericMethod(type, typeof(TResult)))
            .Where(meth => meth.GetParameters()[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<>).MakeGenericType(type, typeof(TResult))))
            .First()
            .Invoke(null, new object[] { table, expression });
    }
