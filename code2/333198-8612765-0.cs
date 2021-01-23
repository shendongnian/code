    [SetUp]
    public void Setup()
    {
    	DesiredCapabilities ieCapabilities = DesiredCapabilities.InternetExplorer();
    	ieCapabilities.SetCapability(InternetExplorerDriver.IntroduceInstabilityByIgnoringProtectedModeSettings, true);
    	driver = new InternetExplorerDriver(ieCapabilities);
    }
