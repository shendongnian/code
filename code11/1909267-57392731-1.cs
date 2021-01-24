    public static partial class ExpressionUtils
    {
    	public static Expression<T> FixMemberAccess<T>(this Expression<T> source)
    	{
    		var body = new MemberAccessFixer().Visit(source.Body);
    		if (body == source.Body) return source;
    		return source.Update(body, source.Parameters);
    	}
    
    	class MemberAccessFixer : ExpressionVisitor
    	{
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			if (node.Expression != null && node.Expression.Type != node.Member.DeclaringType)
    				return Expression.PropertyOrField(node.Expression, node.Member.Name);
    			return base.VisitMember(node);
    		}
    	}
    }
