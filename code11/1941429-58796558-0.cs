        public class ConfigureApiVersioningOptions : IConfigureOptions<ApiVersioningOptions>
        {
            private readonly IServiceProvider _serviceProvider;
            public ConfigureApiVersioningOptions(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }
            public void Configure(ApiVersioningOptions options)
            {
                var apiVersion = _serviceProvider.GetRequiredService<IConfiguration>().GetSection("ApiVersion").Value;
                options.DefaultApiVersion = ApiVersion.Parse(apiVersion);
            }
        }
