    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Support.UI;
    
    //create Actions object
    Actions builder = new Actions(driver);
    //create a chain of actions 
    builder.DoubleClick().Build().Perform();
