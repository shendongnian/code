    public class CustomExpressionVisitor : ExpressionVisitor
    {
        private readonly Type entityType;
        private readonly Type baseEntityType;
        private readonly ParameterExpression param;
    
        public CustomExpressionVisitor(Type entityType, Type baseEntityType, ParameterExpression param)
        {
            this.entityType = entityType;
            this.baseEntityType = baseEntityType;
            this.param = param;
        }
        protected override Expression VisitMember(MemberExpression expression)
        {
            if (expression.Member.DeclaringType == this.baseEntityType)
            {
                return Expression.PropertyOrField(this.param, expression.Member.Name);
            }
    
            return base.VisitMember(expression);
        }
    }
