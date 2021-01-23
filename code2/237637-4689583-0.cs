    public static class ControlBindingsCollectionExtensions
    {
       public static void Add<T>(this ControlBindingsCollection instance, Expression<Func<T, object>> property)
    	{
    		var body = property.Body as UnaryExpression;
    		var member = body.Operand as MemberExpression;
    		var name = member.Member.Name;
            instance.Add(name);
    	}
    }
