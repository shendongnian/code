     public static class PropertyExpressionHelper
     {
        public static TProperty GetProperty<T,TProperty>(this T obj, Expression<Func<T,TProperty>> getPropertyExpression)
        {
            if(obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if(getPropertyExpression==null)
            {
                throw new ArgumentNullException("getPropertyExpression");
            }
            var memberExpression = getPropertyExpression.Body as MemberExpression;
            bool memberExpressionIsInvalidProperty = memberExpression == null ||
                                                     !(memberExpression.Member is PropertyInfo &&
                                                       memberExpression.Expression.Type == typeof (T));
            if(memberExpressionIsInvalidProperty)
            {
                throw new ArgumentNullException("getPropertyExpression", "Not a valid property expression.");
            }
            return (TProperty)(memberExpression.Member as PropertyInfo).GetValue(obj, null);
        }
    }
