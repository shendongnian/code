    [TestClass]
    public abstract class TestBase
    {       
        protected abstract void DragAssignDeviceAndDriver();
        [TestInitialize]
        public void BaseTestInit()
        {
            // create chrome driver
            //driver = new ChromeDriver();
            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("disable-infobars");
            opt.AddArguments("--start-maximized");
            opt.AddArguments("--disable-extensions");
            driver = new ChromeDriver(opt);
            LoginAndSelectAutomationFleet(driver);
            //GenerationTestData();
        }
        public void LoginAndGenerateTestData(IWebDriver driver)
        {
           DragAssignDeviceAndDriver();
        }
      }
---
    [TestClass]
    public class TestScripts1: TestBase
    {
        [TestInitialize]
        public void Setup()
        {
           (_regRep.organizationOption, "Amazing Power", driver);  // <--- ??
        }
        [TestMethod]
        [TestCategory("Cat1")]
        public override void DragAssignDeviceAndDriver()
        {
         //Do stuff   
        }
    }
