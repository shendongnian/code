    public class CustomConfigurationSection : ConfigurationSection
    {
        public CustomConfigurationSection()
        {
            public CustomConfigurationSection()
            {
                Properties.Add(new ConfigurationProperty(
                    "x",
                    typeof(string),
                    null,
                    null,
                    new StringValidator(1), ConfigurationPropertyOptions.IsRequired));
            }
        }
    
        public string X
        {
            get { return (string)this["x"]; }
            set { this["x"] = value; }
        }
    }
