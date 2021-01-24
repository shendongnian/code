    public void ConfigureServices(IServiceCollection services) {
    
        // ...
        EmailSettings settings = Configuration.GetSection("EmailSettings").Get<EmailSettings>();
        services.AddSingleton(settings);
        services.AddSingleton<IEmailSender, EmailSender>();
    }
