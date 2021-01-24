    public static class MyViewModelLocator
    {
        private static readonly IContainer _container = RegisterDependencies();
        private static IContainer RegisterDependencies()
        {
            return new ContainerBuilder()
                // Register services (this is required):
                .RegisterType<IDatabase,MyDatabase>()
                // Register consumers (this is optional and only needed if you're using the ViewModelLocator pattern in your XAML views):
                .RegisterSingleton<ItemsViewModel>()
                .Build();
        }
        public static IContainer Container => _container;
        public static ItemsViewModel ItemsViewModel => _container.Resolve<ItemsViewModel();
    }
