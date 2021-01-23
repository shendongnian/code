    // Runs in LinqPad!
    public class TableQueryObject
    {
    	private readonly Dictionary<string, object> _data = new Dictionary<string, object>();
    	public string TableName { get; set; }
    	public object this[string column]
    	{
    		get { return _data.ContainsKey(column) ? _data[column] : null; }
    		set { if (_data.ContainsKey(column)) _data[column] = value; else _data.Add(column, value); }
    	}
    }
    
    public interface ITableQuery : IEnumerable<TableQueryObject>
    {
    	string TableName { get; }
    	string ConnectionString { get; }
    	Expression Expression { get; }
    	ITableQueryProvider Provider { get; }
    }
    
    public interface ITableQueryProvider
    {
    	ITableQuery Query { get; }
    	IEnumerable<TableQueryObject> Execute(Expression expression);
    }
    
    public interface ITableQueryFactory
    {
    	ITableQuery Query(string tableName);
    }
    
    
    public static class ExtensionMethods
    {
    	class TableQueryContext : ITableQuery
    	{
    		private readonly ITableQueryProvider _queryProvider;
    		private readonly Expression _expression;
    
    		public TableQueryContext(ITableQueryProvider queryProvider, Expression expression)
    		{
    			_queryProvider = queryProvider;
    			_expression = expression;
    		}
    
    		public string TableName { get { return _queryProvider.Query.TableName; } }
    		public string ConnectionString { get { return _queryProvider.Query.ConnectionString; } }
    		public Expression Expression { get { return _expression; } }
    		public ITableQueryProvider Provider { get { return _queryProvider; } }
    		public IEnumerator<TableQueryObject> GetEnumerator() { return Provider.Execute(Expression).GetEnumerator(); }
    		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    	}
    
    	public static MethodInfo MakeGeneric(MethodBase method, params Type[] parameters)
    	{
    		return ((MethodInfo)method).MakeGenericMethod(parameters);
    	}
    
    	public static Expression StaticCall(MethodInfo method, params Expression[] expressions)
    	{
    		return Expression.Call(null, method, expressions);
    	}
    
    	public static ITableQuery CreateQuery(this ITableQueryProvider source, Expression expression)
    	{
    		return new TableQueryContext(source, expression);
    	}
    
    	public static IEnumerable<TableQueryObject> Select<TSource>(this ITableQuery source, Expression<Func<TSource, TableQueryObject>> selector)
    	{
    		return source.Provider.CreateQuery(StaticCall(MakeGeneric(MethodBase.GetCurrentMethod(), typeof(TSource)), source.Expression, Expression.Quote(selector)));
    	}
    
    	public static ITableQuery Where(this ITableQuery source, Expression<Func<TableQueryObject, bool>> predicate)
    	{
    		return source.Provider.CreateQuery(StaticCall((MethodInfo)MethodBase.GetCurrentMethod(), source.Expression, Expression.Quote(predicate)));
    	}
    }
    
    class SqlTableQueryFactory : ITableQueryFactory
    {
    
    	class SqlTableQuery : ITableQuery
    	{
    		private readonly string _tableName;
    		private readonly string _connectionString;
    		private readonly ITableQueryProvider _provider;
    		private readonly Expression _expression;
    
    		public SqlTableQuery(string tableName, string connectionString)
    		{
    			_connectionString = connectionString;
    			_tableName = tableName;
    			_provider = new SqlTableQueryProvider(this);
    			_expression = Expression.Constant(this);
    		}
    
    		public IEnumerator<TableQueryObject> GetEnumerator() { return Provider.Execute(Expression).GetEnumerator(); }
    		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    		public string TableName { get { return _tableName; } }
    		public string ConnectionString { get { return _connectionString; } }
    		public Expression Expression { get { return _expression; } }
    		public ITableQueryProvider Provider { get { return _provider; } }
    	}
    
    	class SqlTableQueryProvider : ITableQueryProvider
    	{
    		private readonly ITableQuery _query;
    		public ITableQuery Query { get { return _query; } }
    		public SqlTableQueryProvider(ITableQuery query) { _query = query; }
    
    		public IEnumerable<TableQueryObject> Execute(Expression expression)
    		{
    			//var connecitonString = _query.ConnectionString;
    			//var tableName = _query.TableName;
    			// TODO visit expression AST (generate any sql dialect you want) and execute resulting sql
                        // NOTE of course the query can be easily parameterized!
    			// NOTE here the fun begins, just return some dummy data for now :)
    			for (int i = 0; i < 100; i++)
    			{
    				var obj = new TableQueryObject();
    				obj["a"] = i;
    				obj["b"] = "blah " + i;
    				yield return obj;
    			}
    		}
    	}
    
    	private readonly string _connectionString;
    	public SqlTableQueryFactory(string connectionString) { _connectionString = connectionString; }
    	public ITableQuery Query(string tableName)
    	{
    		return new SqlTableQuery(tableName, _connectionString);
    	}
    }
    
    static void Main()
    {
    	ITableQueryFactory database = new SqlTableQueryFactory("SomeConnectionString");
    	var result = from row in database.Query("myTbl")
    				 where row["someColumn"] == "1" && row["otherColumn"] == "2"
    				 where row["thirdColumn"] == "2" && row["otherColumn"] == "4"
    				 select row["a"]; // NOTE select executes as linq to objects! FTW
    	foreach(var a in result) 
    	{
    		Console.WriteLine(a);
    	}	
    }
