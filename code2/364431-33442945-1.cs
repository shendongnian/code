    public static class ExpressionHelper {
        public static Expression<Func<TFrom, TTo>> Chain<TFrom, TMiddle, TTo>(
            this Expression<Func<TFrom, TMiddle>> first,
            Expression<Func<TMiddle, TTo>> second
        ) {
            return Expression.Lambda<Func<TFrom, TTo>>(
               new SwapVisitor(second.Parameters[0], first.Body).Visit(second.Body),
               first.Parameters
            );
        }
    
        private class SwapVisitor : ExpressionVisitor {
            private readonly Expression _from;
            private readonly Expression _to;
    
            public SwapVisitor(Expression from, Expression to) {
                _from = from;
                _to = to;
            }
    
            public override Expression Visit(Expression node) {
                return node == _from ? _to : base.Visit(node);
            }
        }
    }
