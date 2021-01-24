    // The class that is accessed in order to get some config setting
    public class AppConfig
    {
        // The provider reads from a physical file when your lib is shipped but in your tests it will be mocked 
    	private readonly AppConfigProvider provider;
    
    	// Constructor used by your app or library
    	public AppConfig() : this(new AppConfigProvider())
    	{
    	}
    
    	// Constructor that can be used by your unit testing framework to inject a mock
    	internal AppConfig(AppConfigProvider provider)
        {
            this.provider = provider;
        }
    	
    	public string InputKey => GetConfigValueOrThrow("InputKey");
    	
    	private string GetConfigValueOrThrow(string configKey)
        {
            string value = provider.GetSetting(configKey);
    
            if (value == null)
                throw new Exception($"A value for key {configKey} is missing in the App.config file.");
    
            return value;
        }
    }
    
    // Provider implementation that actually reads from the app.config file
    internal class AppConfigProvider
    {
        internal virtual string GetSetting(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey];
        }
    }
    
    // In the test class the config values will be returned by a mock instead of a physical file. This example uses Moq as mocking framework.
    public class AppConfigTest
    {
        private Mock<AppConfigProvider> mock;
        private AppConfig appConfig;
    
    	[SetUp]
    	public void Setup()
    	{
    		mock = new Mock<AppConfigProvider>();
    		appConfig = new AppConfig(mock.Object);
    	}
    
        [Test]
        public void TestInputKeyWhenValueIsValid()
        {
            mock.Setup(provider => provider.GetSetting("InputKey")).Returns("12345");
    
            Assert.AreEqual("12345", appConfig.InputKey);
        }
    }
