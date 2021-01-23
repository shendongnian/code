    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    namespace SeleniumWithCsharp
    {
		class Test
		{
			public IWebDriver driver;
		
		
			public void openGoogle()
			{
				// creating Browser Instance
				driver = new FirefoxDriver();
				//Maximizing the Browser
				driver.Manage().Window.Maximize();
				// Opening the URL
				driver.Navigate().GoToUrl("http://google.com");
				driver.FindElement(By.Id("lst-ib")).SendKeys("Hello World");
				driver.FindElement(By.Name("btnG")).Click();
			}
		
			static void Main()
			{
				Test test = new Test();
				test.openGoogle();
			}
		
		}
	}
