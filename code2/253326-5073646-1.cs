    internal static class SecurityExtension
    {
        public static string GetConnetionString(this Configuration config, string databaseName, string provider = "RSAProtectedConfigurationProvider")
        {
            string sectionName = "connectionStrings";
            ConfigurationSection section = config.GetSection(sectionName);
            if (section != null && !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection(provider);
                config.Save();
            }
            
            return WebConfigurationManager.ConnectionStrings[databaseName].ConnectionString;
        }
    }
    
