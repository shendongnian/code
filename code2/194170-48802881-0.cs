    public class ManageService
    {
        public static T CreateServiceClient<T>(string configName)
        {
            string _assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var PluginConfig = ConfigurationManager.OpenExeConfiguration(_assemblyLocation);
            ConfigurationChannelFactory<T> channelFactory = new ConfigurationChannelFactory<T>(configName, PluginConfig, null);
            var client = channelFactory.CreateChannel();
            return client;
        }
    }
