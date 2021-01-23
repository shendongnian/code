    public static class LogManager
    {
        /// <summary>
        /// The name of the default configuration section to read settings from.
        /// </summary>
        /// <remarks>
        /// You can always change the source of your configuration settings by setting another <see cref="IConfigurationReader"/> instance
        /// on <see cref="ConfigurationReader"/>.
        /// </remarks>
        public static readonly string COMMON_LOGGING_SECTION = "common/logging";
    
        private static IConfigurationReader _configurationReader;
