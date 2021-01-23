    private class ExpressionConstantInjector<T, TConstant> : ExpressionVisitor
    {
        private readonly TConstant toInject;
        private readonly ParameterExpression targetParam;
        public EntityExpressionListInjector(TConstant toInject)
        {
            this.toInject = toInject;
            targetParam = Expression.Parameter(typeof(T), "a");
        }
        public Expression<Func<T, bool>> Inject(Expression<Func<T, TConstant, bool>> source)
        {
            return (Expression<Func<T, bool>>) VisitLambda(source);
        }
        protected override Expression VisitLambda<T1>(Expression<T1> node)
        {
            return Expression.Lambda(Visit(node.Body), targetParam);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof (TConstant))
                return Expression.Constant(toInject);
            return targetParam;
        }
    }
