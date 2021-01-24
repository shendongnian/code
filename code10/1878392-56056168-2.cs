    static void Main(string[] args)
            {
                IWebDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("https://experitest.com/selenium-testing");
                IWebElement element = driver.FindElement(By.Id("colorVar"));
                DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
                wait.Timeout = TimeSpan.FromMinutes(2);
                wait.PollingInterval = TimeSpan.FromMilliseconds(250);
    
                Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
                    {
                        String styleAttrib = element.GetAttribute("style");
                        if (styleAttrib.Contains("red"))
                        {
                            return true;
                        }
                        Console.WriteLine("Color is still " + styleAttrib);
                         return false;
                    });
                wait.Until(waiter);
            }
