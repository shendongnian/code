    private static ConfigurationPropertyCollection s_properties;
    static ExampleSection()
    {
            // Predefine properties here
            // Add the properties to s_properties
    }
    
    /// Override the Properties collection and return our custom one.
    protected override ConfigurationPropertyCollection Properties
    {
        get { return s_properties; }
    }
