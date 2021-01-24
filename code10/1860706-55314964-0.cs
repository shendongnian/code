    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        public Startup(IHostingEnvironment environment)
        {
            _environment = environment;
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            var keysFolder = Path.Combine(_environment.ContentRootPath, "Keys");
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
                .SetApplicationName("MyWebsite")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(90))
                .ProtectKeysWithCertificate(cert);
        }
    
        // snip
    }
