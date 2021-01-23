    // Adapted from internal System.Web.Util.OrderingMethodFinder http://referencesource.microsoft.com/#System.Web/Util/OrderingMethodFinder.cs
    class OrderingMethodFinder : ExpressionVisitor
    {
        bool _orderingMethodFound = false;
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var name = node.Method.Name;
            if (node.Method.DeclaringType == typeof(Queryable) && (
                name.StartsWith("OrderBy", StringComparison.Ordinal) ||
                name.StartsWith("ThenBy", StringComparison.Ordinal)))
            {
                _orderingMethodFound = true;
            }
            return base.VisitMethodCall(node);
        }
        public static bool OrderMethodExists(Expression expression)
        {
            var visitor = new OrderingMethodFinder();
            visitor.Visit(expression);
            return visitor._orderingMethodFound;
        }
    }
