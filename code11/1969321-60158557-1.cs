    public static partial class Extensions
    {
    	public static IQueryable<T> ToQueryable<T>(this IQueryable<T> source)
    		=> new Queryable<T>(new QueryProvider(source.Provider), source.Expression);
    
    	class Queryable<T> : IQueryable<T>
    	{
    		internal Queryable(IQueryProvider provider, Expression expression)
    		{
    			Provider = provider;
    			Expression = expression;
    		}
    		public Type ElementType => typeof(T);
    		public Expression Expression { get; }
    		public IQueryProvider Provider { get; }
    		public IEnumerator<T> GetEnumerator() => Provider.Execute<IEnumerable<T>>(Expression)
    			.ToEnumerable().GetEnumerator();
    		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    	}
    
    	class QueryProvider : IQueryProvider
    	{
    		private readonly IQueryProvider source;
    		internal QueryProvider(IQueryProvider source) => this.source = source;
    		public IQueryable CreateQuery(Expression expression)
    		{
    			var query = source.CreateQuery(expression);
    			return (IQueryable)Activator.CreateInstance(
    				typeof(Queryable<>).MakeGenericType(query.ElementType),
    				this, query.Expression);
    		}
    		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    			=> new Queryable<TElement>(this, expression);
    		public object Execute(Expression expression) => source.Execute(expression);
    		public TResult Execute<TResult>(Expression expression) => source.Execute<TResult>(expression);
    	}
    }
