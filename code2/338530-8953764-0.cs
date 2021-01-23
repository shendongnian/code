     public class QueryExpressionVisitor : ExpressionVisitor
    {
        public List<Type> Types
        {
            get;
            private set;
        }
        public QueryExpressionVisitor()
        {
            Types = new List<Type>();
            
        }
        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type.IsGenericTypeDefinition && node.Type.GetGenericTypeDefinition() == typeof(IQueryable<>))
                CheckType(node.Type.GetGenericArguments()[0]);
            return base.VisitConstant(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            CheckType(node.Member.DeclaringType);
            return base.VisitMember(node);
        }
        
        private void CheckType(Type t)
        {
            if (!Types.Contains(t))
            {
                Types.Add(t);
            }
        }
    }
