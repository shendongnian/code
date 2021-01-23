    internal class FlattenInterface<T> : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if(node.Member.DeclaringType == typeof(T))
            {
                return Expression.MakeMemberAccess(
                    node.Expression,
                    node.Expression.Type.GetMember(node.Member.Name).Single());
            }
            return base.VisitMember(node);
        }
    }
