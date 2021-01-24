    [TestFixture]
    [Explicit]
    public class IntegrationTests
    {
        // ...
    }
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void ShouldNotFail()
        {
             // This will run
        }
        [Test]
        [Explicit]
        public void ManualTest()
        {
            // This will be ignored
        }
    }
