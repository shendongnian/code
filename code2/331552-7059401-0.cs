    class CustomInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name == "MethodToIntercept")
                Console.WriteLine("Intercepted!");
            invocation.Proceed();
        }
    }
