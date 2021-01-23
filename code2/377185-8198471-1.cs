    class DefaultValues
    {
        private readonly Dictionary<string, object[]> m_expressions =
            new Dictionary<string, object[]>();
        public DefaultValues Add<T>(Expression<Func<T>> func)
        {
            var methodCall = ((MethodCallExpression)func.Body);
            var name = methodCall.Method.Name;
            var arguments =
                methodCall.Arguments
                    .Select(Evaluate)
                    .ToArray();
            m_expressions.Add(name, arguments);
            return this;
        }
        private static object Evaluate(Expression expression)
        {
            return Expression.Lambda<Func<object>>(
                Expression.Convert(expression, typeof(object)))
                .Compile()();
        }
        public object[] this[string methodName]
        {
            get { return m_expressions[methodName]; }
        }
    }
