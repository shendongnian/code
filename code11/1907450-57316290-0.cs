    public static partial class ExpressionUtils
    {
    	public static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
    		=> new ParameterReplacer { source = source, target = target }.Visit(expression);
    
    	class ParameterReplacer : ExpressionVisitor
    	{
    		public ParameterExpression source;
    		public Expression target;
    		protected override Expression VisitParameter(ParameterExpression node)
    			=> node == source ? target : node;
    	}
    }
