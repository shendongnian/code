    public class MySmsProviderFactory : ISmsProviderFactory
    {
        //Create Provider and initialize with settings
        public ISmsProvider Create(IEnumerable<ISmsProviderSetting> settings)
        {
            var provider = new MySmsProvider();
            provider.LoadSettings(settings);
            return provider;
        }
        public ISmsProvider Create()
        {
            var provider = new MySmsProvider();
            return provider;
        }
        public string Description { get; } = "My Provider";
        public string Name { get; } = typeof(MySmsProvider).FullName;
    }
