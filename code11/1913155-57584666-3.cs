    public static class PredicateBuilder {
        public static Expression<Func<T, bool>> True<T>() { return x => true; }
        public static Expression<Func<T, bool>> False<T>() { return x => false; }
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) {
            return left.Compose(right, Expression.OrElse);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) {
            return left.Compose(right, Expression.AndAlso);
        }
        static Expression<T> Compose<T>(this Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> merge) {
            var p1 = left.Parameters.First();//Only handling with one parameter
            // replace parameters in the second lambda expression with the parameters in the first
            var rightBody = ParameterRebinder.Replaceparameter(p1, right.Body);
            // create a merged lambda expression with parameters from the first expression
            return Expression.Lambda<T>(merge(left.Body, rightBody), left.Parameters);
        }
        private class ParameterRebinder : ExpressionVisitor {
            private ParameterExpression source;
            public ParameterRebinder(ParameterExpression source) {
                this.source = source;
            }
            internal static Expression Replaceparameter(ParameterExpression source, Expression root) {
                return new ParameterRebinder(source).Visit(root);// (Expression<TOutput>)VisitLambda(root);
            }
            protected override Expression VisitParameter(ParameterExpression node) {
                // Replace non matching parameters, visit other params as usual.
                return node.Name != source.Name ? source : base.VisitParameter(node);
            }
        }
    }
