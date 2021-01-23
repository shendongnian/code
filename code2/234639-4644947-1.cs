    public static class ExpressionExtensions
    {
        public static string GetPropertyName<TSource, TMember>(
            this Expression<Func<TSource, TMember>> memberReference)
        {
            var expression = memberReference.Body as MemberExpression;
            if (expression == null)
            {
                var convertexp = memberReference.Body as UnaryExpression;
                if (convertexp != null)
                    expression = convertexp.Operand as MemberExpression; ;
            }
            if (expression == null)
                throw new ArgumentNullException("memberReference");
            return expression.Member.Name;
        }
        private static string GetPropertyName(MethodCallExpression expression)
        {
            var methodCallExpression = expression.Object as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return GetPropertyName(methodCallExpression);
            }
            return expression.Object.ToString();
        }
    }
