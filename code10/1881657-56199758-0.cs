    public class Query // this will contain your 20 fields you want to check against
    {
	    public int? Field1; public int? Field2;	public int? Field3;	public int Field4;
    }
    
    public class QueriedObject // this is the object representing the database table you're querying
    {
	    public int QueriedField;
    }
    public class Program
    {
	    public static void Main()
    	{
	    	var queryable = new List<QueriedObject>().AsQueryable();
		    var query = new Query { Field2 = 1, Field3 = 4, Field4 = 2 };
		
            // this represents the argument to your lambda expression
			var parameter = Expression.Parameter(typeof(QueriedObject), "qo");
            // this is the "qo.QueriedField" part of the resulting expression - we'll use it several times later
			var memberAccess = Expression.Field(parameter, "QueriedField");
			
            // start with a 1 == 1 comparison for easier building - 
            // you can just add further &&s to it without checking if it's the first in the chain
			var expr = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
            // doesn't trigger, so you still have 1 == 1
			if (query.Field1.HasValue)
			{
				expr = Expression.AndAlso(expr, Expression.Equal(memberAccess, Expression.Constant(query.Field1.Value)));
			}
            // 1 == 1 && qo.QueriedField == 1
			if (query.Field2.HasValue)
			{
				expr = Expression.AndAlso(expr, Expression.Equal(memberAccess, Expression.Constant(query.Field2.Value)));
			}
            // 1 == 1 && qo.QueriedField == 1 && qo.QueriedField == 4
			if (query.Field3.HasValue)
			{
				expr = Expression.AndAlso(expr, Expression.Equal(memberAccess, Expression.Constant(query.Field3.Value)));
			}
		
            // (1 == 1 && qo.QueriedField == 1 && qo.QueriedField == 4) || qo.QueriedField == 2
			expr = Expression.OrElse(expr, Expression.Equal(memberAccess, Expression.Constant(query.Field4)));
            // now, we combine the lambda body with the parameter to create a lambda expression, which can be cast to Expression<Func<X, bool>>
			var lambda = (Expression<Func<QueriedObject, bool>>) Expression.Lambda(expr, parameter);
		
            // you can now do this, and the Where will be translated to an SQL query just as if you've written the expression manually
			var result = queryable.Where(lambda);		
		}
	}
