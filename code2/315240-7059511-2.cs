    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<MyApp>().ToSelf();
            //kernel.Bind<IHello>().To<Hello>();
            var app = kernel.Get<MyApp>();
            app.Run();
        }
    }
