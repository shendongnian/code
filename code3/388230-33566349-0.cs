    // Adapted from internal System.Web.Util.OrderingMethodFinder http://referencesource.microsoft.com/#System.Web/Util/OrderingMethodFinder.cs
    class OrderingMethodFinder : ExpressionVisitor
    {
        bool _isTopLevelMethodCall = true;
        bool _orderingMethodFound = false;
        static List<MethodInfo> _orderingMethods = typeof(Queryable).GetMethods().Where(m => 
               m.Name.StartsWith("OrderBy", StringComparison.Ordinal) 
            || m.Name.StartsWith("ThenBy", StringComparison.Ordinal)).ToList();
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (_isTopLevelMethodCall && _orderingMethods.Contains(node.Method))
                _orderingMethodFound = true;
            _isTopLevelMethodCall = false;
            var expr = base.VisitMethodCall(node);
            _isTopLevelMethodCall = true;
            return expr;
        }
        public static bool OrderMethodExists(Expression expression)
        {
            var finder = new OrderingMethodFinder();
            finder.Visit(expression);
            return finder._orderingMethodFound;
        }
    }
