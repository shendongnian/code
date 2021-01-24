    public void ConfigureServices(IServiceCollection services) {
    
        //...assuming other dependencies
        
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddSingleton<EmailStatus>();
        services.AddHostedService<StartupEmailHostedService>();
    }
    
