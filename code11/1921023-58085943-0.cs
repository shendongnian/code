`
using System;
using NUnit.Framework;
using OpenQA.Selenium;
namespace MyTestAutomation.Framework
{
    public class BaseTestFixture
    {
       // this is your singleton webdriver instance -- this gets used throughout the testcase
        public static AndroidDriver<AppiumWebElement> Driver { get; private set; }
        [SetUp]
        public void BaseTestInitialize()
        {     
            // create webdriver instance here
            Driver = DriverFactory.Current.Create();
            
            // call test initialize, which can get overridden in each test case class    
            TestInitialize();
        }
        [TearDown]
        public void BaseTestCleanup()
        {
            // implement TestCleanup() override in your test case class
            TestCleanup(); // clean up after test case -- delete data, etc.
            // universal cleanup: close & quit driver
            Driver.Close();
            Driver.Quit();
        }
        protected virtual void TestInitialize()
        {
            // override this method in your test class & write initialize steps
        }
        protected virtual void TestCleanup()
        {
           // override this method in your test class & write additional cleanup steps
        }
    }
}
`
To use this in action, your test class needs to inherit `BaseTestFixture`, like this:
`
public class MyTestClass : BaseTestFixture
{
    protected override void TestInitialize()
    {
        // initialize your test case here
        // no need to create webdriver, base class method already does this
        // do something like log in to your application here, or navigate to URL
    }
    [Test]
    public void MyTest()
    {
    }
    protected override void TestCleanup()
    {
        // clean up your test case here -- log out, delete data, etc.
        // no need to implement Driver.Close(), base class method already does it 
    }
}
`
With this code sample, you can write a test fixture that handles creating a WebDriver instance & closing it before and after every test. You can override `TestInitialize` and `TestCleanup` if you wish to implement more specific steps at the start and end of each test case. NUnit's `[SetUp]` and `[TearDown]` methods ensure these initialize / cleanup methods will only be run before & after each test case.
