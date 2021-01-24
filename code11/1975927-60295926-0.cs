    .AddFacebook(options =>
    {
        options.ClientId = "xxxxxxxxxxxxx";
        options.ClientSecret = "xxxxxxxxxxxxxxxxxxxx";
        options.CallbackPath = "/signinfacebookcallback";
        options.Events = new OAuthEvents
        {
            OnTicketReceived = ctx =>
            {
                //query the database to get the role
                var db = ctx.HttpContext.RequestServices.GetRequiredService<YourDbContext>();
                // add claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var appIdentity = new ClaimsIdentity(claims);
                ctx.Principal.AddIdentity(appIdentity);
                return Task.CompletedTask;
            },
        };
    });
