        public class Startup
      {
        public Startup(IConfiguration configuration)
        {
          Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddDbContext<DualAuthContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
          services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<DualAuthContext>()
              .AddDefaultTokenProviders();
    
          // Enable Dual Authentication 
          services.AddAuthentication()
            .AddCookie(cfg => cfg.SlidingExpiration = true)
            .AddJwtBearer(cfg =>
            {
              cfg.RequireHttpsMetadata = false;
              cfg.SaveToken = true;
              cfg.TokenValidationParameters = new TokenValidationParameters()
              {
                ValidIssuer = Configuration["Tokens:Issuer"],
                ValidAudience = Configuration["Tokens:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
              };
            });
    
          // Add application services.
          services.AddTransient<IEmailSender, EmailSender>();
          services.AddMvc();
        }
