    public class CustomNamingStrategy : CamelCaseNamingStrategy
    {
        public CustomNamingStrategy()
        {
            ProcessDictionaryKeys = true;
            ProcessExtensionDataNames = true;
            OverrideSpecifiedNames = true;
        }
        public override string GetDictionaryKey(string key)
        {
            return key.ToLower();
        }
    }
