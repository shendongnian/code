    public enum ConfigOption
    {
        Foo,
        Bar
    }
    private static Dictionary<ConfigOption, string> _configLookup = new Dictionary<ConfigOption, string>
    {
        { ConfigOption.Foo, "Foo" },
        { ConfigOption.Bar, "Bar" }
    };
    
    public static string CoolMethod(ConfigOption configOption)
    {
        if (!_configLookup.TryGetValue(configOption, out string value))
        {
            // Handle error
        }
        // Use value retrieved from dictionary.
    }
