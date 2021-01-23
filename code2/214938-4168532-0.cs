    public class ImmutableConfiguration {
        private Configuration _config;
        public ImmutableConfiguration(Configuration config) { _config = config; }
        public string Version { get { return _config.Version; } }
    }
