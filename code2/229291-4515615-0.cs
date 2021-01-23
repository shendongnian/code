    internal class WhereFinder : ExpressionVisitor
        {
            private IList<MethodCallExpression> whereExpressions = new List<MethodCallExpression>();
    
            public IList<MethodCallExpression> GetWhere(Expression expression)
            {
                Visit(expression); 
                return whereExpressions;
            }
    
            protected override Expression VisitMethodCall(MethodCallExpression expression)
            {
                if (expression.Method.Name == "Where")
                    whereExpressions.Add(expression);
    
                Visit(expression.Arguments[0]);
    
                return expression;
            }
        }
