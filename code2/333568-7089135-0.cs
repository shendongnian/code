    void Main()
    {
    	var search = new string[] { "Romania","RO"};
        var query = from c in countries.AllAny(search)
		    orderby c.name
		    select c;
        query.Dump();
    }
    
    public static class QueryExtensions
    {
    	public static IQueryable<T> AllAny<T>(this IQueryable<T> query, string[] search)	
    	{			
    		var properties = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute),true).Any()).Select(n=>n.Name);		
    		var andPredicate = PredicateBuilder.True<T>();
    		foreach ( var term in search )
    		{
    			var orPredicate = PredicateBuilder.False<T>();
    			foreach (var property in properties )
    				orPredicate = orPredicate.Or(CreateLike<T>(property,term));
    			andPredicate = andPredicate.And(orPredicate);
    		}
    		return query.Where(andPredicate);
    	}
    	private static Expression<Func<T,bool>> CreateLike<T>( PropertyInfo prop, string value)
    	{		
    		var parameter = Expression.Parameter(typeof(T), "f");
    		var propertyAccess = Expression.MakeMemberAccess(parameter, prop);            
    		var toString = Expression.Call(propertyAccess, "ToString", null, null);
    		var like = Expression.Call(toString, "Contains", null, Expression.Constant(value,typeof(string)));
    		
    		return Expression.Lambda<Func<T, bool>>(like, parameter);		
    	}
    	
    	private static Expression<Func<T,bool>> CreateLike<T>( string propertyName, string value)
    	{
    		var prop = typeof(T).GetProperty(propertyName);		
    		return CreateLike<T>(prop, value);
    	}
    	
    }
    
    // http://www.albahari.com/nutshell/predicatebuilder.aspx
    public static class PredicateBuilder
    {
      public static Expression<Func<T, bool>> True<T> ()  { return f => true;  }
      public static Expression<Func<T, bool>> False<T> () { return f => false; }
     
      public static Expression<Func<T, bool>> Or<T> (this Expression<Func<T, bool>> expr1,
    													  Expression<Func<T, bool>> expr2)
      {
    	var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
    	return Expression.Lambda<Func<T, bool>>
    		  (Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
      }
     
      public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1,
    													   Expression<Func<T, bool>> expr2)
      {
    	var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
    	return Expression.Lambda<Func<T, bool>>
    		  (Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
      }
    }
