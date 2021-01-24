    public class DiagnosticsSettings
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        public string GetStringValue(string settingName)
        {
            return _dict.TryGetValue(settingName, out var result) ? result : throw new UnknownDiagnosticSettingException($"Unable to locate setting with name {settingName}.");
        }
        public T GetEnumValue<T>(string settingName)
        {
            var stringValue = GetStringValue(settingName);
            if (string.IsNullOrWhiteSpace(stringValue))
                throw new UnknownDiagnosticSettingException($"Unable to locate setting with name { settingName }");
            return (T)Enum.Parse(typeof(T), stringValue);
        }
    }
