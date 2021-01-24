    services.AddScoped<UserRepository>(); // <-- Register UserRepository here
    services.AddAuthentication(options =>
    {
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddFacebook(options =>
       {
             options.AppId = "********";
             options.AppSecret = "*********";
             options.Events.OnCreatingTicket = context =>
             {
                   ........
                   ServiceProvider serviceProvider = services.BuildServiceProvider();
                   var userRepository =  serviceProvider.GetService<UserRepository>();
                        
                   // Do whatever you want to do with userRepository here.
        
                   .........
        
                   return Task.FromResult(0);
              };
       })
