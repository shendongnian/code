    public class Startup
    {
        IConfiguration Configuration;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<SmtpSettings>(Configuration.GetSection("Smtp"));
            services.AddTransient<IEmailSender, EmailSender>();
           
            services.AddMvc();
        }
    }
