    public static class TypeMember<TClass>
    {
        public static string PropertyName<TProp>(Expression<Func<TClass, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'expression' should be a property expression");
            return body.Member.Name;
        }
    }
    TypeMember<string>PropertyName(s => s.Length);
