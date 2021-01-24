    int CountConditions(Expression expr)
    {
        var visitor = new CountBinaryOpsVisitor();
        visitor.Visit(expr);
        return visitor.BinaryOperationCount + 1;
    }
    
    class CountBinaryOpsVisitor : ExpressionVisitor
    {
        public int BinaryOperationCount { get; private set; }
    
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.ExclusiveOr:
                    // Don't count bitwise integer operations, if they are even supported?
                    if (node.Left.Type == typeof(bool))
                        BinaryOperationCount++;
                    break;
            }
            return base.VisitBinary(node);
        }
    }
