        using (IWebDriver driver = new ChromeDriver(this.SeleniumDriverPath, driveroptions))
                    {
                        try
                        {
                            driver.Navigate().GoToUrl("http://www.google.com/");
                            IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("link");
                        query.Submit();
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                            var listElement = driver.FindElements(OpenQA.Selenium.By.XPath(".//*[@id='search']//div[@class='g']"));
                            foreach( var e in listElement)
                            {
								        // parent element:
                                var parent = e.FindElement(OpenQA.Selenium.By.XPath("./.."));   //parent element
        parent.Click();
                            }
                        }
                        catch(Exception ex)
                        {
                            ...
                        }
                        driver.Quit();
                    }
                    
