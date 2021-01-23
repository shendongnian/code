    [TestInitialize]
    public void LoadValidConfig()
    {
        ConfigSetup setup;
        ConfigController.LoadConfig(out setup);
        configSetup = value;
    }
