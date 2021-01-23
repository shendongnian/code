    class MyExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression NewParameterExp { get; private set; }
        public MyExpressionVisitor(ParameterExpression newParameterExp)
        {
            NewParameterExp = newParameterExp;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return NewParameterExp;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(MyClass1))
                return Expression.MakeMemberAccess(this.Visit(node.Expression), 
                   typeof(MyClass2).GetMember(node.Member.Name).FirstOrDefault());
            return base.VisitMember(node);
        }
    }
