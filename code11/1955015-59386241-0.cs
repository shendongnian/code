    using System;
    using System.Text;
    using Microsoft.Web.Administration;
    
    internal static class Sample
    {
    
        private static void Main()
        {
    
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();
    
                ConfigurationSection webFarmsSection = config.GetSection("webFarms");
    
                ConfigurationElementCollection webFarmsCollection = webFarmsSection.GetCollection();
    
                ConfigurationElement webFarmElement = FindElement(webFarmsCollection, "webFarm", "name", @"123213");
                if (webFarmElement == null) throw new InvalidOperationException("Element not found!");
    
    
                ConfigurationElementCollection webFarmCollection = webFarmElement.GetCollection();
    
                ConfigurationElement serverElement = FindElement(webFarmCollection, "server", "address", @"11.1.1.1");
                if (serverElement == null) throw new InvalidOperationException("Element not found!");
    
                serverElement["enabled"] = false;
    
                serverManager.CommitChanges();
            }
        }
    
        private static ConfigurationElement FindElement(ConfigurationElementCollection collection, string elementTagName, params string[] keyValues)
        {
            foreach (ConfigurationElement element in collection)
            {
                if (String.Equals(element.ElementTagName, elementTagName, StringComparison.OrdinalIgnoreCase))
                {
                    bool matches = true;
    
                    for (int i = 0; i < keyValues.Length; i += 2)
                    {
                        object o = element.GetAttributeValue(keyValues[i]);
                        string value = null;
                        if (o != null)
                        {
                            value = o.ToString();
                        }
    
                        if (!String.Equals(value, keyValues[i + 1], StringComparison.OrdinalIgnoreCase))
                        {
                            matches = false;
                            break;
                        }
                    }
                    if (matches)
                    {
                        return element;
                    }
                }
            }
            return null;
        }
    }
