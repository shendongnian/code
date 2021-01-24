    public class Search
    {
    	private IEnumerable<MyClass> _data;
    
    	public Search(IEnumerable<MyClass> data)
    	{
    		_data = data;
    	}
    
    	public IEnumerable<MyClass> Find(Expression<Func<SubClass, bool>> expr)
    	{
    		ParameterExpression x = Expression.Parameter(typeof(MyClass), "x");
    		PropertyInfo p = typeof(MyClass).GetProperty("Child");
    
    		var propertyExpression = (expr.Body as BinaryExpression).Left as MemberExpression;
    		var constant = (expr.Body as BinaryExpression).Right;
    
    		var memberAccess = Expression.MakeMemberAccess(x, p);
    		var upperMemberAccess = Expression.MakeMemberAccess(memberAccess, propertyExpression.Member);
    
    		var equals = Expression.Equal(upperMemberAccess, constant);
    
    		var expression = Expression.Lambda<Func<MyClass, bool>>(equals, x);
    
    		return _data.Where(expression.Compile());
    	}
    }
