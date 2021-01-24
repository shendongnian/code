    public static class EmitUtils
    {
            private class ParameterReplacerVisitor : ExpressionVisitor
            {
                private ParameterExpression _source;
                private Expression _target;
    
                public ParameterReplacerVisitor(ParameterExpression source, Expression target)
                {
                    _source = source;
                    _target = target;
                }
    
                public override Expression Visit(Expression node) =>
                    node == _source
                        ? _target
                        : base.Visit(node);
            }
    
            public static Expression ReplaceParameter(Expression body, ParameterExpression srcParameter, Expression dstParameter) =>
                new ParameterReplacerVisitor(srcParameter, dstParameter).Visit(body);
    
            public static Expression<Func<T1, T3>> BuildClosure<T1, T2, T3>(Expression<Func<T1, T2, T3>> src, T2 closureValue)
            {
                var constExpression = Expression.Constant(closureValue, typeof(T2));
                var body = ReplaceParameter(src.Body, src.Parameters[1], constExpression);
                return Expression.Lambda<Func<T1, T3>>(body, src.Parameters[0]);
            }
                    
        }
