     public class SqlServerSemesterMethodCallTranslator : IMethodCallTranslator
    {
        public Expression Translate(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Method.DeclaringType != typeof(Period)) {
                return null;
            }
            var methodName = methodCallExpression.Method.Name;
            // Implement your Method translations here
            return null;
        }
    }
