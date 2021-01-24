		public Dictionary<string, RemoteWebDriver> Drivers;
        
		public RemoteWebDriver AddDriver(string testName, string url, ICapabilities capabilities)
        {
			var driver = new ThreadLocal<RemoteWebDriver>(() =>
			{
				return new RemoteWebDriver(new Uri(url), capabilities);
			}).Value;
			Drivers.Add(testName, driver);
			TestBase.StaticLogInfo($"Added driver for test: {testName}");
			return Drivers[testName];
        }
