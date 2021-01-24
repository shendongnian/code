    IWebDriver _webDriver = null;
     var firefoxOptions = new FirefoxOptions
                                {
                                    LogLevel = FirefoxDriverLogLevel.Debug,
                                    BrowserExecutableLocation = Configuration.Developer.SeleniumBrowserExecutableLocation
                                };
    
                                firefoxOptions.AddArguments("no-sandbox");
                                firefoxOptions.AddArguments("-headless");
    
                                _webDriver = new RemoteWebDriver(new Uri($"{Configuration.Developer.SeleniumRemoteUrl}"), firefoxOptions);
      _webDriver.Manage().Window.Maximize();
                            _webDriver.Manage().Cookies.DeleteAllCookies();
                            _webDriver.Url = $"https://www.YourSite.com/";
                            _webDriver.Navigate();
                            var wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 30));
     var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("jumbo-hero")));
                            var imageContent = element.GetAttribute("innerHTML");
                            _webDriver.Quit();
       var fromSrc = doc.DocumentNode.Descendants("img").Where(e => e.Attributes.Contains("src") && string.IsNullOrWhiteSpace(e.Attributes["src"].Value) == false).Select(e => e.Attributes["src"].Value).ToList();
                            var fromDataSrc = doc.DocumentNode.Descendants("img").Where(e => e.Attributes.Contains("data-src") && string.IsNullOrWhiteSpace(e.Attributes["data-src"].Value) == false).Select(e => e.Attributes["data-src"].Value).ToList();
