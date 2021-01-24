    public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder) {
        //...
        app.UseExceptionHandler(errorApp  => { 
            errorApp.Run(async context => {
                IServiceProvider services = context.RequestServices;
                IEmailSender emailSender = services.GetRequiredService<IEmailSender>();
                
                await emailSender.SendEmailAsync("someone@gmail.com", "some subject", "hey an exception error!");
            });
        });
        //...
    }
