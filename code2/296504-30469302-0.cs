    public static class DapperExtensions
	{
		public static IEnumerable<T> Query<T>(this IDbConnection connection, Func<T> typeBuilder, string sql)
		{
			return connection.Query<T>(sql);
		}
	}
