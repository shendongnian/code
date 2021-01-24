    public static class QueryTransformExtensions
    { 
    	public static IQueryable<T> TransformFilters<T>(this IQueryable<T> source)
    	{
    		var expression = new TranformVisitor().Visit(source.Expression);
    		if (expression == source.Expression) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    
    	class TranformVisitor : ExpressionVisitor
    	{
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Method.IsStatic && node.Method.Name.StartsWith("Has")
    				&& node.Type.IsGenericType && node.Type.GetGenericTypeDefinition() == typeof(IQueryable<>)
    				&& node.Arguments.Count > 0 && node.Arguments.First().Type == node.Type)
    			{
    				var source = Visit(node.Arguments.First());
    				var elementType = source.Type.GetGenericArguments()[0];
    				var fakeQuery = EmptyQuery(elementType);
    				var args = node.Arguments
    					.Select((arg, i) => i == 0 ? fakeQuery : Evaluate(Visit(arg)))
    					.ToArray();
    				var result = (IQueryable)node.Method.Invoke(null, args);
    				var transformed = result.Expression.Replace(fakeQuery.Expression, source);
    				return Visit(transformed); // Apply recursively
    			}
    			return base.VisitMethodCall(node);
    		}
    
    		static IQueryable EmptyQuery(Type elementType) =>
    			Array.CreateInstance(elementType, 0).AsQueryable();
    
    		static object Evaluate(Expression source)
    		{
    			if (source is ConstantExpression constant)
    				return constant.Value;
    			if (source is MemberExpression member)
    			{
    				var instance = member.Expression != null ? Evaluate(member.Expression) : null;
    				if (member.Member is FieldInfo field)
    					return field.GetValue(instance);
    				if (member.Member is PropertyInfo property)
    					return property.GetValue(instance);
    			}
    			throw new NotSupportedException();
    		}
    	}
    
    	static Expression Replace(this Expression source, Expression from, Expression to) =>
    		new ReplaceVisitor { From = from, To = to }.Visit(source);
    
    	class ReplaceVisitor : ExpressionVisitor
    	{
    		public Expression From;
    		public Expression To;
    		public override Expression Visit(Expression node) =>
    			node == From ? To : base.Visit(node);
    	}
    }
