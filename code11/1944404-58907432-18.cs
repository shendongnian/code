    public static class SlackLoggerBuilderExtension {
        public static ILoggingBuilder AddSlack(this ILoggingBuilder builder) {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ILoggerProvider, SlackLoggerProvider>();
            //or
            //builder.Services.AddSingleton<ILoggerProvider>(sp => 
            //    new SlackLoggerProvider(sp.GetRequiredService<IHttpClientFactory>())
            //);
            return builder;
        }
    }
