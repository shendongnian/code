    class Interceptor : IInterceptor
    {
        private static readonly PropertyInfo BoundMethodsProperty =
            typeof(BindableBase).GetProperty(
                "BoundMethods", BindingFlags.Instance | BindingFlags.NonPublic);
        public void Intercept(IInvocation invocation)
        {
            var boudMethods =
                (Dictionary<string, Action>)BoundMethodsProperty.GetValue(
                    invocation.InvocationTarget, null);
            invocation.Proceed();
            string method = invocation.Method.Name;
            Action action;
            if (boudMethods.TryGetValue(method, out action))
                action();
        }
    }
