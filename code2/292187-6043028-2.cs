    public static class PropertyUtil<TSource>
    {
        public static string GetPropertyName<TResult>(
            Expression<Func<TSource, TResult>> propertyExpression)
        {
           return (propertyExpression.Body as MemberExpression).Member.Name;
        }
    }
