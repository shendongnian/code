    public CustomConfigurationSection : ConfigurationSection
    {
        public CustomConfigurationSection()
        {
            Properties.Add(new ConfigurationProperty(
                    "x",
                    typeof(string),
                    null,
                    new StringValidator(1)));
        }
    
        public string X
        {
            get { return (string)this["x"]; }
            set { this["x"] = value; }
        }
    }
