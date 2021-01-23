		private static Func<int> Wrap(MyDelegate dele)
		{
			var fn = dele.Method;
			var result = ParameterExpression.Variable(typeof(int));
			var block = BlockExpression.Block(
				typeof(int),
				new[] { result },
				new Expression[]
				{
					Expression.Call(fn, result),
					result,
				});
			return Expression.Lambda<Func<int>>(block).Compile();
		}
