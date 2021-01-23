    public static Type GetObjectType<T>(Expression<Func<T, object>> expr)
    {
        if ((expr.Body.NodeType == ExpressionType.Convert) ||
            (expr.Body.NodeType == ExpressionType.ConvertChecked))
        {
            var unary = expr.Body as UnaryExpression;
            if (unary != null)
                return unary.Operand.Type;
        }
        return expr.Body.Type;
    }
