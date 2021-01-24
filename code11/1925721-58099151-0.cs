    static void Main(string[] args)
    {
        Expression<Func<MyType, bool>> a = t => t.Id == 1;
        Expression<Func<MyType, bool>> b = t => t.Name == "Name1";
        Expression<Func<MyType, bool>> c = t => t.Desc == "Desc1";
        Expression<Func<MyType, bool>> combined = LinqExtensions.And(a, b, c);
        await myIQueryableOfMyType
            .Where(combined)
            .ToArrayAsync()
    }
    public static class LinqExtensions
    {
        // Combine array of predicates into one
        // For example for input:
        //    [ t1 => t1.Id == 1, t2 => t2.Name == "Name1", t3 => t3.Desc == "Desc1" ]
        // output will be
        //    p => p.Id == 1 && p.Name == "Name1" && p.Desc == "Desc1"
        public static Expression<Func<T, bool>> And<T>(params Expression<Func<T, bool>>[] predicates)
        {
            // this is `p`
            ParameterExpression param = Expression.Parameter(typeof(T));
            Expression body = null;
            foreach (Expression<Func<T, bool>> predicate in predicates)
            {
                body = body == null
                    // first expression, just assign it to body
                    ? predicate.Body
                    // join body with predicate using &&
                    : Expression.AndAlso(body, predicate.Body);
            }
            
            // Create lambda
            return Expression.Lambda<Func<T, bool>>(
                // this is where we replace t1, t2, t3 with p
                new ParamExpressionVisitor(param).Visit(body),
                param
            );
        }
        private class ParamExpressionVisitor : ExpressionVisitor
        {
            private ParameterExpression _parameter;
            public ParamExpressionVisitor(ParameterExpression parameter)
            {
                this._parameter = parameter;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node.Type == this._parameter.Type)
                {
                    return this._parameter;
                }
                
                return base.VisitParameter(node);
            }
        }
    }
