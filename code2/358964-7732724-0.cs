    public class SomeCrazyClass<T>
    {
        private Expression<Func<T>> _method;
        public void SetExecutableMethod(Expression<Func<T>> methodParam)
        {
            _method = methodParam;
        }
        public object ExecuteMethod(SomeService someService, object[] parameterValues)
        {
            var methodCallExpression = _method.Body as MethodCallExpression;
            var method = methodCallExpression.Method;
            var methodCall = Expression.Call(Expression.Constant(someService), method,
                                    parameterValues.Select(Expression.Constant));
            return Expression.Lambda(methodCall).Compile().DynamicInvoke();
        }
    }
