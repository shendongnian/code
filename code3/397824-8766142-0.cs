    protected override Expression VisitBinary(BinaryExpression node)
    {
        if (node.NodeType == ExpressionType.Divide)
        {
            var rightExpression = node.Right;
            // compile the right expression and get his value            
            var newRightExpression = Evaluate(rightExpression);
            return node.Update(node.Left, node.Conversion, newRightExpression);
        }
        return base.VisitBinary(node);
    }
