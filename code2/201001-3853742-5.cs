    public void ConfigureLog4Net()
    {
        XmlConfigurator.Configure();
        GlobalContext.Properties["CurrentLine"] = WebLoggingHelper.CurrentLine;
    }
