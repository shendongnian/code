    public static Type GetObjectType<T>(Expression<Func<T, object>> expr)
    {
        var body = expr.Body;
        if ((body.NodeType == ExpressionType.Convert) ||
            (body.NodeType == ExpressionType.ConvertChecked))
        {
            var unary = body as UnaryExpression;
            if (unary != null)
                return unary.Operand.Type;
        }
        return body.Type;
    }
