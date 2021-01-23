    class LoggingIntereceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method);
            invocation.Proceed();
        }
    }
    …
    public static void Run1()
    {
        var generator = new ProxyGenerator();
        IFooable fooable = generator.CreateInterfaceProxyWithTarget<IFooable>(
            new FooImplementation(), new LoggingIntereceptor());
        InvokeFoo(fooable);
    }
