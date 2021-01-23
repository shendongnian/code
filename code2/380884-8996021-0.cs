	public partial class YourObjectContext
	{
		private static MethodInfo GetMethodInfo(Expression<Action> expression)
		{
			return ((MethodCallExpression)expression.Body).Method;
		}
		public IQueryable<TResult> CreateScalarQuery<TResult>(Expression<Func<TResult>> expression)
		{
			return QueryProvider.CreateQuery<TResult>(
				Expression.Call(
					method: GetMethodInfo(() => Queryable.Select<int, TResult>(null, (Expression<Func<int, TResult>>)null)),
					arg0: Expression.Call(
						method: GetMethodInfo(() => Queryable.AsQueryable<int>(null)),
						arg0: Expression.NewArrayInit(typeof(int), Expression.Constant(1))),
						arg1: Expression.Lambda(body: expression.Body, parameters: new[] { Expression.Parameter(typeof(int)) })));
		}
	}
