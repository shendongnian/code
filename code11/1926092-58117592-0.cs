    Dictionary<string, object> browserStackOptions = new Dictionary<string, object>();
    browserStackOptions.Add("userName", ConfigurationManager.AppSettings.Get("user"));
    browserStackOptions.Add("accessKey", ConfigurationManager.AppSettings.Get("key"));
    browserStackOptions.Add("os", "Windows");
    browserStackOptions.Add("osVersion", "10");
    browserStackOptions.Add("sessionName", TestName);
    ChromeOptions options = new ChromeOptions();
    // N.B., the below line of code is specific to
    // the 4.0 alpha of the .NET bindings. To
    // use a 3.x version, use:
    // options.AddAdditionalCapability("bstack:options", browserStackOptions, true);
    options.AddAdditionalOption("bstack:options", browserStackOptions);
    IWebDriver driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), options);
