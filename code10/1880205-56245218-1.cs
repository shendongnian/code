    public static partial class ExpressionExtensions
    {
    	public static Expression ReplaceParameter(this Expression source, ParameterExpression from, Expression to)
    		=> new ParameterReplacer { From = from, To = to }.Visit(source);
    
    	class ParameterReplacer : ExpressionVisitor
    	{
    		public ParameterExpression From;
    		public Expression To;
    		protected override Expression VisitParameter(ParameterExpression node) => node == From ? To : base.VisitParameter(node);
    	}
    }
