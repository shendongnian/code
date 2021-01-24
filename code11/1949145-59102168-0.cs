    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
            // configure jwt authentication
            var secret = Encoding.ASCII.GetBytes(appSettings.Secret);
        }
