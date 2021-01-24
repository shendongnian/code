    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
             if (context.Request.Query.ContainsKey("access_token"))
             {
                  context.Token = context.Request.Query["access_token"];
             }
             return Task.CompletedTask;
        }
    };
