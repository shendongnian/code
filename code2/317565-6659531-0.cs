    public static class ModelHelper
    {
        public static string Item<T>(this T obj, Expression<Func<T, object>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                return ((MemberExpression)(expression.Body)).Member.Name;
            }
            if (expression.Body is UnaryExpression)
            {
                return ((MemberExpression)((UnaryExpression)(expression.Body)).Operand)
                        .Member.Name;
            }
            throw new InvalidOperationException();
        }
    }
