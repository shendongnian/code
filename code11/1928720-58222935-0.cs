        var driveroptions = new ChromeOptions();
                    driveroptions.AddUserProfilePreference("disable-popup-blocking", "true");
            
                    using (IWebDriver driver = new ChromeDriver(this.SeleniumDriverPath, driveroptions))
                    {
                        try
                        {
                            driver.Navigate().GoToUrl("http://www.google.com/");
                            IWebElement query = driver.FindElement(By.Name("q"));
                            query.SendKeys("link");
                            query.Submit();
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                            //
                            var listElement = driver.FindElements(OpenQA.Selenium.By.XPath(".//*[@id='search']//div[@class='g']"));
                            foreach( var e in listElement)
                            {
                                //include ctrl+click:
                                //var action = new OpenQA.Selenium.Interactions.Actions(driver);
                                //action.KeyDown(Keys.Control).Build().Perform();
                                //or click:
                                if ("Supreme®/Honda®/Fox® Racing Puffy Zip Up Jacket".Contains(e.Text))
                                {
                                    e.Click();
                                }
                            }
                            //
                        }
                        driver.Quit();
                    }
