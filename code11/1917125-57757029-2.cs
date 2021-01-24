    public class MyExpressionVisitor : ExpressionVisitor{
        private List<string> parts;
    
        protected override Expression VisitMember(MemberExpression node)
        {
            parts.Add(node.Member.Name);
            return base.VisitMember(node);
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            parts.Add(node.Type.Name);
            return base.VisitParameter(node);
        }
    
        public string GetPath(Expression e)
        {
            parts = new List<string>();
            Visit(e is LambdaExpression ? ((LambdaExpression)e).Body : e);
            parts.Reverse();
            return string.Join(".", parts);
        }
    }
