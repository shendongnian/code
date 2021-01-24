    public class UnaryConstant1 : ExpressionVisitor {
        protected override Expression VisitBinary(BinaryExpression node) {
            if (node.Right is ConstantExpression c && c.Type.IsNumeric() && (Int32)c.Value == 1) {
                if (node.NodeType == ExpressionType.Add || node.NodeType == ExpressionType.Subtract) {
                    if (node.Left is MemberExpression) {
                        if (node.NodeType == ExpressionType.Add)
                            return Expression.Increment(node.Left);
                        else
                            return Expression.Decrement(node.Left);
                    }
                    else if (node.Left is BinaryExpression left && (left.NodeType == ExpressionType.Add || left.NodeType == ExpressionType.Subtract)) {
                        Expression right;
                        if (node.NodeType == ExpressionType.Add)
                            right = Expression.Increment(left.Right);
                        else
                            right = Expression.Decrement(left.Right);
    
                        if (left.NodeType == ExpressionType.Add)
                            return Expression.Add(Visit(left.Left), right);
                        else
                            return Expression.Subtract(Visit(left.Left), right);
                    }
                }
            }
            return base.VisitBinary(node);
        }
    }
