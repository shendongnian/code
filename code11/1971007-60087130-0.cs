    [AutoMap(typeof(ConfigurationSetting), ReverseMap = false)]
    public class ConfigurationSettingDTO
    {
        [ValueConverter(typeof(ConfigurationSettingConverter))]
        public ConfigurationSettingKey Key { get; set; }
        public string Value { get; set; }
    }
