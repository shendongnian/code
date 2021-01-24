    public class ConfigurationSettingConverter : IValueConverter<string, ConfigurationSettingKey>
    {
        public ConfigurationSettingKey Convert(string source, ResolutionContext context)
        {
            return ConfigurationSettingKey.GetSettingKeyById(source);
        }
    }
