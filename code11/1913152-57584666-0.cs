    public static class PredicateBuilder {
        public static Expression<Func<T, bool>> True<T>() { return x => true; }
        public static Expression<Func<T, bool>> False<T>() { return x => false; }
        
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) {
            var p1 = left.Parameters.First();
            var p2 = right.Parameters.First();
            if (p1.Name != p2.Name) {
                var replacer = new ParameterReplacerVisitor<Func<T, bool>>(p1);
                right = replacer.VisitAndConvert(right);
            }
            var newBody = Expression.OrElse(left.Body, right.Body);
            return Expression.Lambda<Func<T, bool>>(newBody, left.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) {
            var p1 = left.Parameters.First();
            var p2 = right.Parameters.First();
            if (p1.Name != p2.Name) {
                var replacer = new ParameterReplacerVisitor<Func<T, bool>>(p1);
                right = replacer.VisitAndConvert(right);
            }
            var newBody = Expression.AndAlso(left.Body, right.Body);
            return Expression.Lambda<Func<T, bool>>(newBody, left.Parameters);
        }
        
        private class ParameterReplacerVisitor<TOutput> : ExpressionVisitor {
            private ParameterExpression source;
            public ParameterReplacerVisitor(ParameterExpression source) {
                this.source = source;
            }
            internal Expression<TOutput> VisitAndConvert<T>(Expression<T> root) {
                return (Expression<TOutput>)VisitLambda(root);
            }
            protected override Expression VisitLambda<T>(Expression<T> node) {
                //All parameters that don't match source.
                var parameters = node.Parameters.Select(p => p.Name != source.Name ? source : p);
                return Expression.Lambda<TOutput>(Visit(node.Body), parameters);
            }
            protected override Expression VisitParameter(ParameterExpression node) {
                // Replace non matching parameters, visit other params as usual.
                return node.Name != source.Name ? source : base.VisitParameter(node);
            }
        }
    }
