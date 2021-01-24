    public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder) {
        //...
        app.UseExceptionHandler(errorApp  => { 
            errorApp.Run(async context => {
                IServiceProvider services = context.RequestServices;
                IEmailSender emailSender = services.GetRequiredService<IEmailSender>();
                UserExceptionOptions options = services.GetRequiredService<IOptions<UserExceptionOptions>>().Value;
                await emailSender.SendEmailAsync(options.ExceptionEmailAddress, "some subject", "hey an exception error!");
            });
        });
        //...
    }
