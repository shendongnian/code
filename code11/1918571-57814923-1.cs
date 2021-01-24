public class RequestSizeLimitFromConfigAttribute : Attribute, IFilterFactory
    {
        private string _configurationKey;
        public RequestSizeLimitFromConfigAttribute(string configurationKey)
        {
            _configurationKey = configurationKey;
        }
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = serviceProvider.GetRequiredService<RequestSizeLimitFilter>();
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            filter.Bytes = config.GetValue<int>(_configurationKey);
            return filter;
        }
...
    }
