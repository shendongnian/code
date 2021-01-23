    public class PredicateRewriter
    {
        public static Expression<Predicate<T>> Rewrite<T>(Expression<Predicate<T>> exp, string newParamName)
        {
            var param = Expression.Parameter(exp.Parameters[0].Type, newParamName);
            var newExpression = new PredicateRewriterVisitor(param).Visit(exp);
            return (Expression<Predicate<T>>) newExpression;
        }
        private class PredicateRewriterVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _parameterExpression;
            public PredicateRewriterVisitor(ParameterExpression parameterExpression)
            {
                _parameterExpression = parameterExpression;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameterExpression;
            }
        }
    }
