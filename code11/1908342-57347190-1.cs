    public static class MyViewModelLocator
    {
        private static readonly IContainer _container = RegisterDependencies();
        private static IContainer RegisterDependencies()
        {
            return new ContainerBuilder()
                .RegisterType<IDatabase,MyDatabase>()
                .Build();
        }
        public static IContainer Container => _container;
    }
