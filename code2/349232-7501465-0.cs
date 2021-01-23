    public class ExtensionConfigurationElement<TConfigSection, UDefaultValue>
        where UDefaultValue : new() 
        where TConfigSection : ConfigurationElement, new()
    {
        public UDefaultValue GetDefaultValue(string strField)
        {
            TConfigSection tConfigSection = new TConfigSection();
            ConfigurationElement configElement = tConfigSection as ConfigurationElement;
            if (configElement == null)
            {
                // not a config section
                System.Diagnostics.Debug.Assert(false);
                return default(UDefaultValue);
            }
            ElementInformation elementInfo = configElement.ElementInformation;
            var varTest = elementInfo.Properties;
            foreach (var item in varTest)
            {
                PropertyInformation propertyInformation = item as PropertyInformation;
                if (propertyInformation == null || propertyInformation.Name != strField)
                {
                    continue;
                }
                try
                {
                    UDefaultValue defaultValue = (UDefaultValue) propertyInformation.DefaultValue;
                    return defaultValue;
                }
                catch (Exception ex)
                {
                    // default value of the wrong type
                    System.Diagnostics.Debug.Assert(false);
                    return default(UDefaultValue);                
                }
            }
            return default(UDefaultValue);
        }
    }
