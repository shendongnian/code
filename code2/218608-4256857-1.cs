    ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;
    
            if (settings != null)
            {
                foreach(ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
