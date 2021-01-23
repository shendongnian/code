    public interface I1
    {
        void Method1();
    }
    public interface I2
    {
        void Method2();
    }
    public class C : I1, I2
    {
        public int Data = 0;
        [Log]
        public void Method1() { Console.WriteLine("Method1 " + Data); Data = 1; }
        [Log]
        public void Method2() { Console.WriteLine("Method2 " + Data); Data = 2; }
    }
    public class LogAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogCallHandler();
        }
    }
    public class LogCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Entering " + input.MethodBase.Name);
            var methodReturn = getNext().Invoke(input, getNext);
            Console.WriteLine("Leaving " + input.MethodBase.Name);
            return methodReturn;
        }
        public int Order { get; set; }
    } 
    void Test()
    {
        IUnityContainer container = new UnityContainer();
        container.AddNewExtension<Interception>();
        container.RegisterType<C>(new ContainerControlledLifetimeManager());
        container.RegisterType<I1, C>();
        container.RegisterType<I2, C>();
        container.Configure<Interception>().SetInterceptorFor<I1>(new TransparentProxyInterceptor());
        container.Configure<Interception>().SetInterceptorFor<I2>(new TransparentProxyInterceptor());
        container.Resolve<I1>().Method1();
        container.Resolve<I2>().Method2();
        container.Resolve<C>().Method2();
    }
