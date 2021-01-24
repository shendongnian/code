    public static class SlackLoggerBuilderExtension {
        public static ILoggingBuilder AddSlack(this ILoggingBuilder builder) {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ILoggerProvider, SlackLoggerProvider>();
            return builder;
        }
    }
