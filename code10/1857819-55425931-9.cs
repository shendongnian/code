    public static partial class ExpressionUtils
    {
    	public static Expression<Func<TOuter, TResult>> Apply<TOuter, TInner, TResult>(this Expression<Func<TOuter, TInner>> outer, Expression<Func<TInner, TResult>> inner)
    		=> Expression.Lambda<Func<TOuter, TResult>>(inner.Body.ReplaceParameter(inner.Parameters[0], outer.Body), outer.Parameters);
    
    	public static Expression<Func<TOuter, TResult>> ApplyTo<TOuter, TInner, TResult>(this Expression<Func<TInner, TResult>> inner, Expression<Func<TOuter, TInner>> outer)
    		=> outer.Apply(inner);
    }
