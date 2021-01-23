    public static void ImplementsAttribute<TType, TProperty>(this TType obj, Expression<Func<TType, TProperty>> expression)
    {
         var memberExpression = expression.Body as MemberExpression;
         var name = MetaHelper.GetPropertyName(expression);
         var property = memberExpression.Expression.Type.GetProperty(name);
         var attributes = property.GetCustomAttributes(true);
         Assert.IsTrue(attributes.Any(a => a is TX));
    }
