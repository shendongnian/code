    public class Program
        private readoonly IClientDataService service;
        
        public Program(IClientDataService service) {
            this.service = service;
        }
        
        public void SomeMethod() {
            //...
        }
        
        //entry
        public static void Main(string[] args) {
            IServiceProvider serviceProvider = RegisterServices();
        
            Program program = serviceProvider.GetService<Program>();
            
            program.SomeMethod();
            
            DisposeServices(serviceProvider);
        }
        
        //Support
        private static IServiceProvider RegisterServices() {
            var collection = new ServiceCollection();
            //repositories
            collection.AddScoped<IAccountDataRepository, AccountDataRepository>();
            collection.AddScoped<IClientDataRepository, ClientDataRepository>();
            collection.AddScoped<IAddressDataRepository, AddressDataRepository>();
            collection.AddScoped<IClientAccountDataRepository, ClientAccountDataRepository>();
            //services
            collection.AddScoped<IAccountDataService, AccountDataService>();
            collection.AddScoped<IClientDataService, ClientDataService>();
            collection.AddScoped<IAddressDataService, AddressDataService>();
            collection.AddScoped<IClientAccountDataService, ClientAccountDataService>();
            //main
            collection.AddScoped<Program>(); //<-- NOTE THIS
            return collection.BuildServiceProvider();
        }
        
        private static void DisposeServices(IServiceProvider serviceProvider) {
            if (serviceProvider == null) {
                return;
            }
            if (serviceProvider is IDisposable sp) {
                sp.Dispose();
            }
        }
    }
