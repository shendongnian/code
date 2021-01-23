    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConnectionStringAttribute : Attribute     
    {
        /// <summary>
        /// Denotes the setting that you want to populate the given property with.
        /// </summary>
        public string SettingName { get; private set; }
        public ConnectionStringAttribute(string configSettingName = "")
        {
            SettingName = configSettingName;
        }
    }
