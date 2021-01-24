    public static partial class ExpressionUtils
    {
        public static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
            => new ParameterReplacer { Source = source, Target = target }.Visit(expression);
    
        class ParameterReplacer : ExpressionVisitor
        {
            public ParameterExpression Source;
            public Expression Target;
            protected override Expression VisitParameter(ParameterExpression node)
                => node == Source ? Target : node;
        }
    } 
