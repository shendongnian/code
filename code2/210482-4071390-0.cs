    private static void Main() {
        
        using(ServerManager serverManager = new ServerManager()) { 
            Configuration config = serverManager.GetApplicationHostConfiguration();
            
            ConfigurationSection ipSecuritySection = config.GetSection("system.webServer/security/ipSecurity");
            
            ConfigurationElementCollection ipSecurityCollection = ipSecuritySection.GetCollection();
            
            ConfigurationElement addElement = FindElement(ipSecurityCollection, "add", "ipAddress", @"169.132.124.234", "subnetMask", @"255.255.255.255", "domainName", @"");
            if (addElement == null) throw new InvalidOperationException("Element not found!");
            
            ipSecurityCollection.Remove(addElement);
            
            serverManager.CommitChanges();
        }
    }
    
    private static ConfigurationElement FindElement(ConfigurationElementCollection collection, string elementTagName, params string[] keyValues) {
        foreach (ConfigurationElement element in collection) {
            if (String.Equals(element.ElementTagName, elementTagName, StringComparison.OrdinalIgnoreCase)) {
                bool matches = true;
    
                for (int i = 0; i < keyValues.Length; i += 2) {
                    object o = element.GetAttributeValue(keyValues[i]);
                    string value = null;
                    if (o != null) {
                        value = o.ToString();
                    }
    
                    if (!String.Equals(value, keyValues[i + 1], StringComparison.OrdinalIgnoreCase)) {
                        matches = false;
                        break;
                    }
                }
                if (matches) {
                    return element;
                }
            }
        }
        return null;
    }
