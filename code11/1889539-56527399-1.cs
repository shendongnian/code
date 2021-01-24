    public class ContainerInit {
        public static IContainer BuildContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainClass>().As<IMainClass>().SingleInstance();
            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
            var logger = LoggUtil.CreateLogger();
            builder.Register(logger).As<ILogger>().SingleInstance();
    
            var container = builder.Build();
            return container;
        }
    }
