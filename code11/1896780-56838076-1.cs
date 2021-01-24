    public class ApplicationProperties : IApplicationProperties
    {
        private readonly Application _application;
        public ApplicationProperties(Application application)
        {
            _application = application;
        }
        public object GetProperty(string key)
        {
            // or whatever behavior you want when the key is missing
            return _application.Properties.TryGetValue(key, out object result) ? result : null;
        }
        public void SetProperty(string key, object value)
        {
            _application.Properties[key] = value;
        }
        public async Task SavePropertiesAsync()
        {
            await _application.SavePropertiesAsync();
        }
    }
