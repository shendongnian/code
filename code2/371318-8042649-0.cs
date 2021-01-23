    public static class Guard
    {
        public static void NotNullOrEmpty(Expression<Func<string>> parameterExpression)
        {
            string value = parameterExpression.Compile()();
            if (String.IsNullOrWhiteSpace(value))
            {
                string name = GetParameterName(parameterExpression);
                throw new ArgumentException("Cannot be null or empty", name);
            }
        }
        public static void NotNull<T>(Expression<Func<T>> parameterExpression)
            where T : class
        {
            if (null == parameterExpression.Compile()())
            {
                string name = GetParameterName(parameterExpression);
                throw new ArgumentNullException(name);
            }
        }
        private static string GetParameterName<T>(Expression<Func<T>> parameterExpression)
        {
            dynamic body = parameterExpression.Body;
            return body.Member.Name;
        }
    }
