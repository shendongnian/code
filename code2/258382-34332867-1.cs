        private AppSettingsSection _appSettings;
        NumberFormatInfo _nfi;
        public Settings(Assembly currentAssembly)
        {
            UriBuilder uri = new UriBuilder(currentAssembly.CodeBase);
            string configPath = Uri.UnescapeDataString(uri.Path);
            Configuration myDllConfig = ConfigurationManager.OpenExeConfiguration(configPath);
            _appSettings = myDllConfig.AppSettings;
            _nfi = new NumberFormatInfo() 
            { 
                NumberGroupSeparator = "", 
                CurrencyDecimalSeparator = "." 
            };
        }
        public T Setting<T>(string name)
        {
            try
            {
                return (T)Convert.ChangeType(_appSettings.Settings[name].Value, typeof(T), _nfi);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
