Startup:
        public void ConfigureServices(IServiceCollection services)
        {
         //some code...
                services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
        }
