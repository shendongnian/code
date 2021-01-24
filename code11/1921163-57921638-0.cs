    public static class LinqExtensions
    {
        public static IQueryable<T> FixQuery<T>(this IQueryable<T> query)
        {
            return query.Provider.CreateQuery<T>(
                new FixQueryVisitor().Visit(query.Expression)
            );
        }
        class FixQueryVisitor : ExpressionVisitor
        {
            private readonly MethodInfo _likeMethod = ExtractMethod(() => EF.Functions.Like(string.Empty, string.Empty)); 
            private static MethodInfo ExtractMethod(Expression<Action> expr)
            {
                MethodCallExpression body = (MethodCallExpression)expr.Body;
                return body.Method;
            }
            
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.DeclaringType == typeof(string) && node.Method.Name == "Contains")
                {
                    return Expression.Call(this._likeMethod, Expression.Constant(EF.Functions), node.Object, node.Arguments[0]);
                }
                
                return base.VisitMethodCall(node);
            }
        }
    }
    [...]
    dataSource = dataSource.FixQuery();
