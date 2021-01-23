    public class TimeServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ITimeService>().To<TimeService>();
            this.Bind<ServiceHost>().ToMethod(ctx => ctx.Kernel.Get<NinjectServiceHost>(new ConstructorArgument("singletonInstance", c => c.Kernel.Get<ITimeService>())));
        }
    }
    internal static class Program
    {
        private static void Main()
        {
            var kernel = new StandardKernel(new TimeServiceModule());
            var serviceHost = kernel.Get<ServiceHost>();
            serviceHost.AddServiceEndpoint(typeof(ITimeService), new NetTcpBinding(), "net.tcp://localhost/TimeService");
            try
            {
                serviceHost.Open();
            }
            finally
            {
                serviceHost.Close();
            }
        }
    }
