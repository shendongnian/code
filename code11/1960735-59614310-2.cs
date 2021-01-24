    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        //REMOVED IContainer. It is not needed
        public void ConfigureContainer(ServiceRegistry services) {
            //Apply scan to the registry used by framework so container is aware of types.
            services.Scan(scanner => {
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory(a =>
                    a.FullName.Contains("Test3.1"));
                scanner.WithDefaultConventions();
                scanner.SingleImplementationsOfInterface();
            });
            services
                .AddControllers(options => {
                    // Disable automatic fallback to JSON
                    options.ReturnHttpNotAcceptable = true;
                    // Honor browser's Accept header (e.g. Chrome)
                    options.RespectBrowserAcceptHeader = true;
                })
                .AddControllersAsServices();
            services.AddMvc()
                .AddControllersAsServices();
            services.WhatDidIScan();
            services.WhatDoIHave();
            Console.Write("Container Instantiated");
        }
        //...omitted for brevity
    }
