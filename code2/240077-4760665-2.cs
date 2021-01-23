    // using System;
    // using System.Linq.Expressions;
    
    public static class ClotureRemover
    {
    #region Public Methods
    public static Expression<TExpressionType> RemoveCloture<TExpressionType>(
        this Expression<TExpressionType> e)
    {
        var converter = new RemoveClotureVisitor();
        var newBody = converter.Visit(e.Body);
        return Expression.Lambda<TExpressionType>(newBody, e.Parameters);
    }
    #endregion
    private class RemoveClotureVisitor : ExpressionVisitor
    {
        public RemoveClotureVisitor()
        {
        }
        public override Expression Visit(Expression node)
        {
            if (!RequiresParameterVisitor.RequiresParameter(node))
            {
                Expression<Func<object>> funct = () => new object();
                funct = Expression.Lambda<Func<object>>(Expression.Convert(node, typeof(object)), funct.Parameters);
                object res = funct.Compile()();
                return ConstantExpression.Constant(res, node.Type);
            }
            return base.Visit(node);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if ((node.NodeType == ExpressionType.AndAlso) || (node.NodeType == ExpressionType.OrElse))
            {
                Expression newLeft = Visit(node.Left);
                Expression newRight = Visit(node.Right);
                bool isOr = (node.NodeType == ExpressionType.OrElse);
                bool value;
                if (IsBoolConst(newLeft, out value))
                {
                    if (value ^ isOr)
                    {
                        return newRight;
                    }
                    else
                    {
                        return newLeft;
                    }
                }
                if (IsBoolConst(newRight, out value))
                {
                    if (value ^ isOr)
                    {
                        return newLeft;
                    }
                    else
                    {
                        return newRight;
                    }
                }
            }
            return base.VisitBinary(node);
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert || node.NodeType == ExpressionType.ConvertChecked)
            {
                Expression newOpperand = Visit(node.Operand);
                if (newOpperand.Type == node.Type)
                {
                    return newOpperand;
                }
            }
            return base.VisitUnary(node);
        }
        private static bool IsBoolConst(Expression node, out bool value)
        {
            ConstantExpression asConst = node as ConstantExpression;
            if (asConst != null)
            {
                if (asConst.Type == typeof(bool))
                {
                    value = (bool)asConst.Value;
                    return true;
                }
            }
            value = false;
            return false;
        }
    }
    private class RequiresParameterVisitor : ExpressionVisitor
    {
        protected RequiresParameterVisitor()
        {
            result = false;
        }
        public static bool RequiresParameter(Expression node)
        {
            RequiresParameterVisitor visitor = new RequiresParameterVisitor();
            visitor.Visit(node);
            return visitor.result;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            result = true;
            return base.VisitParameter(node);
        }
        internal bool result;
    }
}
