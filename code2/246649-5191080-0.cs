    /// <summary>
    /// Dynamic wrapper for <see cref="AppSettingsSection"/>.
    /// </summary>
    public class DynamicAppSettings : DynamicObject
    {
        private string _exeConfigPath;
        private System.Configuration.Configuration _config;
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicAppSettings"/> class with configuration file
        /// of the current application domain.
        /// </summary>
        public DynamicAppSettings()
            : this(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicAppSettings"/> class with the specified configuration file.
        /// </summary>
        /// <param name="exeConfigPath">Path to configuration file.</param>
        public DynamicAppSettings(string exeConfigPath)
        {
            if (string.IsNullOrEmpty(exeConfigPath))
                throw new ArgumentNullException("exeConfigPath");
            _exeConfigPath = exeConfigPath;
            _config = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap() { ExeConfigFilename = _exeConfigPath },
                ConfigurationUserLevel.None);
        }
        /// <summary>
        /// Gets the application settings entry from the configuration file.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _config.AppSettings.Settings[binder.Name];
            return true;
        }
        /// <summary>
        /// Adds or updates application settings entry.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value != null && !(value is string))
            {
                return base.TrySetMember(binder, value);
            }
            if (_config.AppSettings.Settings[binder.Name] != null)
            {
                _config.AppSettings.Settings[binder.Name].Value = value.ToString();
            }
            else
            {
                _config.AppSettings.Settings.Add(binder.Name, value.ToString());
            }
            return true;
        }
        /// <summary>
        /// Invokes <see cref="Configuration.Save"/> method to save changes or removes an entry.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name.Equals("Save", StringComparison.OrdinalIgnoreCase))
            {
                _config.Save();
                result = null;
                return true;
            }
            if (binder.Name.Equals("Remove", StringComparison.OrdinalIgnoreCase) &&
                args != null && args.Length == 1 && (args[0] is string))
            {
                _config.AppSettings.Settings.Remove(args[0].ToString());
                result = null;
                return true;
            }
            return base.TryInvokeMember(binder, args, out result);
        }
    }
    /// <summary>
    /// Dynamic wrapper for <see cref="ConnectionStringsSection"/>.
    /// </summary>
    public class DynamicConnectionStrings : DynamicObject
    {
        private string _exeConfigPath;
        private System.Configuration.Configuration _config;
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicConnectionStrings"/> class with the configuration file
        /// of the current application domain.
        /// </summary>
        public DynamicConnectionStrings()
            : this(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicConnectionStrings"/> class with the specified
        /// configuration file.
        /// </summary>
        /// <param name="exeConfigPath">Path to the configuration file.</param>
        public DynamicConnectionStrings(string exeConfigPath)
        {
            if (string.IsNullOrEmpty(exeConfigPath))
                throw new ArgumentNullException("exeConfigPath");
            _exeConfigPath = exeConfigPath;
            _config = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap() { ExeConfigFilename = _exeConfigPath },
                ConfigurationUserLevel.None);
        }
        /// <summary>
        /// Gets the connection string value from the configuration file.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _config.ConnectionStrings.ConnectionStrings[binder.Name].ConnectionString;
            return true;
        }
        /// <summary>
        /// Adds or updates a connection string entry in the configuration file.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value != null && !(value is string))
            {
                return base.TrySetMember(binder, value);
            }
            if (_config.ConnectionStrings.ConnectionStrings[binder.Name] != null)
            {
                _config.ConnectionStrings.ConnectionStrings[binder.Name].ConnectionString = value.ToString();
            }
            else
            {
                _config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings(binder.Name, value.ToString()));
            }
            return true;
        }
        /// <summary>
        /// Invokes <see cref="Configuration.Save"/> to save changes or removes an entry.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name.Equals("Save", StringComparison.OrdinalIgnoreCase))
            {
                _config.Save();
                result = null;
                return true;
            }
            if (binder.Name.Equals("Remove", StringComparison.OrdinalIgnoreCase) &&
                args != null && args.Length == 1 && (args[0] is string))
            {
                _config.ConnectionStrings.ConnectionStrings.Remove(args[0].ToString());
                result = null;
                return true;
            }
            return base.TryInvokeMember(binder, args, out result);
        }
    }
