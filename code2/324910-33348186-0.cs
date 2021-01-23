	public class ExpressionMerger : ExpressionVisitor
	{
		Expression CurrentParameterExpression { get; set; }
		public Expression<Func<TIn, TOut>> Merge<TIn, TA, TOut>(Expression<Func<TIn, TA>> inner, Expression<Func<TA, TOut>> outer)
		{
			return MergeAll<TIn, TOut>(inner, outer);
		}
		public Expression<Func<TIn, TOut>> Merge<TIn, TA, TB, TOut>(Expression<Func<TIn, TA>> inner, Expression<Func<TA, TB>> transition, Expression<Func<TB, TOut>> outer)
		{
			return MergeAll<TIn, TOut>(inner, transition, outer);
		}
		protected Expression<Func<TIn, TOut>> MergeAll<TIn, TOut>(params LambdaExpression[] expressions)
		{
			CurrentParameterExpression = expressions[0].Body;
			foreach (var expression in expressions.Skip(1))
			{
				CurrentParameterExpression = Visit(expression.Body);
			}
			return Expression.Lambda<Func<TIn, TOut>>(CurrentParameterExpression, expressions[0].Parameters[0]);
		} 
		protected override Expression VisitParameter(ParameterExpression node)
		{
			//replace current lambda parameter with ~previous lambdas
			return CurrentParameterExpression;
		}
	}
}
