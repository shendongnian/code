    public static IEnumerable<TResult> ExecuteSqlStringAccessor<TResult>(this Database database, string sqlString)
        where TResult : new()
    {
        return CreateSqlStringAccessor<TResult>(database, sqlString).Execute();   
    }
