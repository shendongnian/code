    public static partial class ExpressionUtils
    {
        public static Expression<Func<TOuter, bool>> Any<TOuter, TInner>(Expression<Func<TOuter, IEnumerable<TInner>>> innerSelector, Expression<Func<TInner, bool>> innerPredicate)
        {
        	var parameter = innerSelector.Parameters[0];
        	var body = Expression.Call(
        		typeof(Enumerable), nameof(Enumerable.Any), new[] { typeof(TInner) },
        		innerSelector.Body, innerPredicate);
        	return Expression.Lambda<Func<TOuter, bool>>(body, parameter);
        }
    }
