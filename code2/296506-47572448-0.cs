    public static IEnumerable<T> Query<T>(this IDbConnection connection, Func<T> typeBuilder,
        string sql, dynamic param = null, IDbTransaction transaction = null,
        bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
    {
        return SqlMapper.Query<T>(connection, sql, param, transaction, buffered,
            commandTimeout, commandType);
    }
