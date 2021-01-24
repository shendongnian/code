            public IConfiguration _config { get; set; }
        public Startup(IConfiguration configuration) {
            _config = configuration;
        }
   
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddMvc();
            services.AddDbContext<TodoContext>(options => options.UseSqlServer(_config.GetSection("ConnectionStrings")["todo"]));
        }
