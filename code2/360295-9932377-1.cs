    namespace Tests
    {
    [TestFixture]
    public abstract class Test
    {
        private static bool _flagSetUp;
        private static bool _flagTearDown;
        public IWebDriver driver { get; private set; };
        protected Test()
        {
        }
        public static void SetFlag(bool flagSetUp, bool flagTearDown)
        {
            _flagSetUp = flagSetUp;
            _flagTearDown = flagTearDown;
        }
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            if(_flagSetUp)
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://www.google.com/");
                _flagSetUp = false;
            }
        }
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if(_flagTearDown)
            {
                driver.Quit();
            }
        }
    }
    namespace Tests
    {
    [TestFixture(new object[] { true, false })]
    public class A_Test : Test
    {
        public A_Test(bool flagSetUp, bool flagTearDown)
        {
            SetFlag(flagSetUp, flagTearDown);
        }
        [Test]
        public void Test1()
        {
           ...
        }
    }
    namespace Tests
    {
    [TestFixture(new object[] { false, true })]
    public class Z_Test : Test
    {
        public A_Test(bool flagSetUp, bool flagTearDown)
        {
            SetFlag(flagSetUp, flagTearDown);
        }
        [Test]
        public void Test2()
        {
           ...
        }
    }
