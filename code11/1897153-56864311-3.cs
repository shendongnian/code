    public static class CustomAuthExtensions
    {
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>("MyScheme", "MyAuth", configureOptions);
        }
        public static AuthenticationBuilder AddCustomAuthTwo(this AuthenticationBuilder builder, Action<CustomAuthOptionsTwo> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptionsTwo, CustomAuthHandlerTwo>("MyScheme2", "MyAuth2", configureOptions);
        }
    }
