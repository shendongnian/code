    public abstract class AbstractTests
    {
        protected abstract DefaultSelenium CreateSelenium();
        [Test]
        public void TestSomethingA()
        {
            DefaulSelenium selenium = CreateSelenium();
            //Do some testing with selenium.
        }
    }
    [TestFixture]
    public class IETests : AbstractTests
    {
        protected override DefaultSelenium CreateSelenium()
        {
            return new DefaultSelenium("iexplore");
        }
    }
    [TestFixture]
    public class FirefoxTests : AbstractTests
    {
        protected override DefaultSelenium CreateSelenium()
        {
            return new DefaultSelenium("firefox");
        }
    }
