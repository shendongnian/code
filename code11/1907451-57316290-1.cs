    public static partial class ExpressionUtils
    {
    	public static Expression<Func<TOuter, TResult>> Select<TOuter, TInner, TResult>(
    		this Expression<Func<TOuter, TInner>> innerSelector,
    		Expression<Func<TInner, TResult>> resultSelector)
    		=> Expression.Lambda<Func<TOuter, TResult>>(
    			resultSelector.Body.ReplaceParameter(resultSelector.Parameters[0], innerSelector.Body),
    			innerSelector.Parameters);
    }
