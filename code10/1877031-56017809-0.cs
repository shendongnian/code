    using OpenQA.Selenium.Chrome;
    
    var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");
    
                using (var driver = new ChromeDriver(chromeOptions))
                {
                    driver.Navigate().GoToUrl("https://fantasy.eliteserien.no/a/statistics/cost_change_start");
    
                    // As IWebElement
                    var fantasyTable = driver.FindElementByClassName("ism-scroll-table");
    
                    // Content as text-string
                    string fantasyTableText = fantasyTable.Text;
    
                    // As Html-string
                    string fantasyTableAsHtml = fantasyTable.GetAttribute("innerHTML");
    
                    // My code for handling the data follows here...
                    
                }
