    public class ConfigurationSettingKeyResolver : IValueResolver<ConfigurationSetting, ConfigurationSettingDTO, ConfigurationSettingKey>
    {
        public ConfigurationSettingKey Resolve(ConfigurationSetting source, ConfigurationSettingDTO destination, ConfigurationSettingKey key, ResolutionContext context)
        {
            // YOUR VALUE TO BE RETURNED HERE, YOU MIGHT WANT TO DOUBLE CHECK YOUR IMPLEMENTATION HERE
            return ConfigurationSettingKey.GetSettingKeyById(source.Key);
        }
    }
