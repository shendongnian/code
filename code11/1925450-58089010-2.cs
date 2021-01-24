    public class APIConfiguration : IAPIConfiguration {
        public APIConfiguration(IConfiguration configuration) {
            this.API_KEY = configuration["API:Key"] ?? throw new NoNullAllowedException("API key wasn't found.");
            this._url = configuration["API:URL"] ?? throw new NoNullAllowedException("API url wasn't found.");
        }
        public string API_KEY { get; }
        private string _url;
        public Uri URL {
            get {
                return new Uri(this._url);
            }
        }
    }
