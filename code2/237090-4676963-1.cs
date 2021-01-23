    public class FieldMapBuilder<TFrom, TTo>
    {
    	private Expression<Action<TFrom, TTo>>[] _fieldMaps = null;
    	
    	public FieldMapBuilder()
    	{
    		_fieldMaps = new Expression<Action<TFrom, TTo>>[] { };
    	}
    	
    	public FieldMapBuilder(Expression<Action<TFrom, TTo>>[] fieldMaps)
    	{
    		_fieldMaps = fieldMaps;
    	}
    	
    	public FieldMapBuilder<TFrom, TTo> AddMap<P>(
            Expression<Func<TFrom, P>> source,
            Expression<Func<TTo, P>> destination)
    	{
    		return this.AddMap<P, P>(source, destination, x => x);
    	}
    	
    	public FieldMapBuilder<TFrom, TTo> AddMap<PFrom, PTo>(
            Expression<Func<TFrom, PFrom>> source,
            Expression<Func<TTo, PTo>> destination,
            Expression<Func<PFrom, PTo>> map)
    	{
    		var paramFrom = Expression.Parameter(typeof(TFrom), "from");
    		var paramTo = Expression.Parameter(typeof(TTo), "to");
    
    		var invokeExpressionFrom =
                    Expression.Invoke(map, Expression.Invoke(source, paramFrom));
    
    		var propertyExpressionTo =
                    Expression.Property(paramTo,
    			(destination.Body as MemberExpression).Member as PropertyInfo);
    		
    		var assignmentExpression =
                    Expression.Assign(propertyExpressionTo, invokeExpressionFrom);
    		
    		return new FieldMapBuilder<TFrom, TTo>(
                    _fieldMaps.Concat(new Expression<Action<TFrom, TTo>>[]
                    {
                        Expression.Lambda<Action<TFrom, TTo>>(
                            assignmentExpression,
                            paramFrom,
                            paramTo)
                    }).ToArray());
    	}
    
    	public Action<TFrom, TTo> Compile()
    	{
    		var paramFrom = Expression.Parameter(typeof(TFrom), "from");
    		var paramTo = Expression.Parameter(typeof(TTo), "to");
    		
    		var expressionBlock =
    			Expression.Block(_fieldMaps
    				.Select(fm => Expression.Invoke(fm, paramFrom, paramTo))
    				.ToArray());
    			
    		var lambda = Expression.Lambda<Action<TFrom, TTo>>(
    			expressionBlock, 
    			paramFrom,
    			paramTo);
    	
    		return lambda.Compile();
    	}
    }
