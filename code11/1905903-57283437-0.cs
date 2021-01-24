    public class CustomNamingStrategy : CamelCaseNamingStrategy
    {
        public CustomNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames) : base(
            processDictionaryKeys, overrideSpecifiedNames)
        {
        }
        public CustomNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames) : base(
            processDictionaryKeys, overrideSpecifiedNames, processExtensionDataNames)
        {
        }
        public CustomNamingStrategy() : base()
        {
        }
        public override string GetDictionaryKey(string key)
        {
            if (!ProcessDictionaryKeys)
            {
                return key;
            }
            if (Decimal.TryParse(key, out var result))
            {
                return result.ToString(CultureInfo.InvariantCulture);
            }
            return ResolvePropertyName(key);
        }
    }
