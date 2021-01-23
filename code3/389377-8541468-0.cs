	public class Renamer : ExpressionVisitor
	{
	    public Expression Rename(Expression expression)
	    {
	        return Visit(expression);
	    }
	
	    Expression VisitParameter(ParameterExpression node)
		{
			if (node.Name == "a")
				return Expression.Parameter(node.Type, "something_else");
			else
				return node;
		}
	}
