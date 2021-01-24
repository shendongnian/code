    public static void AddCustomJwtBearer(this AuthenticationBuilder builder, Action<JwtBearerOptions> options)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfigureOptions>());
            builder.AddScheme<JwtBearerOptions, JwtBearerHandler>("Bearer", null, options);
        }
    /// <summary>
    /// Returns a configured <see cref="JwtBearerEvents"/>
    /// </summary>
    /// <param name="tokenConfiguration">Token Configuration</param>
    /// <returns><see cref="JwtBearerEvents"/></returns>
    private static JwtBearerEvents ConfigureJwtEvents(TokenConfiguration tokenConfiguration)
    {
        var bearerEvents = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
   
             return Task.CompletedTask;
            }
        };
        // Authentication Failed Method
        bearerEvents.OnAuthenticationFailed = [YOUR-EVENT-HANDLER]
        // Challenge Raised Event
        bearerEvents.OnChallenge = [YOUR-EVENT-HANDLER]
            
        // Message Received Event
        bearerEvents.OnMessageReceived = [YOUR-EVENT-HANDLER]
            
        // Token Validated Event
        bearerEvents.OnTokenValidated = [YOUR-EVENT-HANDLER]
        return bearerEvents;
    }
