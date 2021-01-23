    public void SelTest(IConfigurationService config)
    {
        var selenium = new DefaultSelenium(config.GetValue("TestMachine"),
            4444, config.GetValue("Browser"), config.GetValue("URL"));
    }
