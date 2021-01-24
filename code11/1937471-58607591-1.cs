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
            var services = new ServiceCollection();
            //repositories
            services.AddScoped<IAccountDataRepository, AccountDataRepository>();
            services.AddScoped<IClientDataRepository, ClientDataRepository>();
            services.AddScoped<IAddressDataRepository, AddressDataRepository>();
            services.AddScoped<IClientAccountDataRepository, ClientAccountDataRepository>();
            //services
            services.AddScoped<IAccountDataService, AccountDataService>();
            services.AddScoped<IClientDataService, ClientDataService>();
            services.AddScoped<IAddressDataService, AddressDataService>();
            services.AddScoped<IClientAccountDataService, ClientAccountDataService>();
            //main
            services.AddScoped<Program>(); //<-- NOTE THIS
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
