    public static Expression<Func<TFrom, TTo>> AndLambdas<TFrom, TTo>(this Expression<Func<TFrom, TTo>> first, Expression<Func<TFrom, TTo>> second)
    {
        ParameterExpression paramToUse = first.Parameters[0];
        Expression bodyLeft = first.Body;
        ConversionVisitor visitor = new ConversionVisitor(paramToUse, second.Parameters[0]);
        Expression bodyRight = visitor.Visit(second.Body);
        return Expression.Lambda<Func<TFrom, TTo>>(Expression.MakeBinary(ExpressionType.AndAlso, bodyLeft, bodyRight), first.Parameters);
    }
    class ConversionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression newParameter;
        private readonly ParameterExpression oldParameter;
        public ConversionVisitor(ParameterExpression newParameter, ParameterExpression oldParameter)
        {
            this.newParameter = newParameter;
            this.oldParameter = oldParameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return newParameter; // replace all old param references with new ones
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != oldParameter) // if instance is not old parameter - do nothing
                return base.VisitMember(node);
            var newObj = Visit(node.Expression);
            var newMember = newParameter.Type.GetMember(node.Member.Name).First();
            return Expression.MakeMemberAccess(newObj, newMember);
        }
    }
