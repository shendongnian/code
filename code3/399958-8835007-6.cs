    sb.AppendLine("<td>");
    var unary = column.Property.Body as UnaryExpression;
    if (unary != null && unary.NodeType == ExpressionType.Convert)
    {
        var lambda = Expression.Lambda(unary.Operand, column.Property.Parameters[0]);
        sb.AppendLine(itemHelper.Display(ExpressionHelper.GetExpressionText(lambda)).ToHtmlString());
    }
    else
    {
        sb.AppendLine(itemHelper.DisplayFor(column.Property).ToHtmlString());
    }
    sb.AppendLine("</td>");
