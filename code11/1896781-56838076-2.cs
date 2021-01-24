    // base class
    public abstract class ApplicationPropertiesBase : IApplicationProperties
    {
        protected abstract IDictionary<string, object> Properties { get; }
        public object GetProperty(string key)
        {
            return Properties.TryGetValue(key, out object result) ? result : null;
        }
        public void SetProperty(string key, object value)
        {
            Properties[key] = value;
        }
        public abstract Task SavePropertiesAsync();
    }
    // inject this
    public class ApplicationProperties : ApplicationPropertiesBase
    {
        private readonly Application _application;
        public ApplicationProperties(Application application)
        {
            _application = application;
        }
        protected override IDictionary<string, object> Properties => _application.Properties;
        public override async Task SavePropertiesAsync()
        {
            await _application.SavePropertiesAsync();
        }
    }
    // use for tests 
    public class ApplicationPropertiesTestDouble : ApplicationPropertiesBase
    {
        private readonly IDictionary<string, object> properties = 
            new Dictionary<string, object>();
        protected override IDictionary<string, object> Properties => properties;
        public override async Task SavePropertiesAsync()
        { }
    }
