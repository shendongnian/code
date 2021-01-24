    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddAzureAd(options =>
    {
        Configuration.Bind("AzureAd", options);
    });
    services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        // TicketReceived event is called when the authentication process
        // is completed but right before the SignIn happens
        options.Events.OnTicketReceived = async (context) =>
        {
            var user = context.Principal;
            userValidator = context.HttpContext.Services.GetService<IUserValidator>();
            var isValid = await userValidator.ValidateUser(user);
 
            if (!isValid)
            {
                context.Fail("User is not allowed");
                context.Response.Redirect("/error/user-not-allowed");
                return;
            }
            context.Success();
        };
    });
