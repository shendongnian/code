    public class MemberModifier : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            var t = typeof (DepartmentPaperConsumption);
            var memberInfo = t.GetMember("TotalPages")[0];
            return Expression.MakeMemberAccess(node.Expression, memberInfo);
        }
    }
