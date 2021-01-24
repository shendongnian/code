    public static class Reusables {
        public static IDependencyProvider DependencyProvider;
    
        private static Lazy<IServiceProvider> serviceProvider = 
            new Lazy<IServiceProvider>(() => DependencyProvider.BuildServiceProvider());
    
        public static IServiceProvider GetServiceProvider() {
            return serviceProvider.Value;
        }
    }
