    public static class ObjectExtensions
    {
        public static string NameOf<T>(this T target, Expression<Func<T, object>> propertyExpression)
        {
            MemberExpression body = null;
            if (propertyExpression.Body is UnaryExpression)
            {
                var unary = propertyExpression.Body as UnaryExpression;
                if (unary.Operand is MemberExpression)
                    body = unary.Operand as MemberExpression;
            }
            else if (propertyExpression.Body is MemberExpression)
            {
                body = propertyExpression.Body as MemberExpression;
            }
            if (body == null)
                throw new ArgumentException("'propertyExpression' should be a member expression");
            // Extract the right part (after "=>")
            var vmExpression = body.Expression as ConstantExpression;
            // Extract the name of the property
            return body.Member.Name;
        }
    }
