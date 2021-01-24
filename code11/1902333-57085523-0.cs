    [TestFixture]
    public class Tests
    {
        private int valueBeingPassed;
        [OneTimeSetUp]
        public void Setup()
        {
            valueBeingPassed = 1;
        }
        [Test, Order(1)]
        public void Test1()
        {
            valueBeingPassed += 2;
            Assert.AreEqual(valueBeingPassed, 3);
        }
        [Test, Order(2)]
        public void Test2()
        {
            var doubleValue = valueBeingPassed * 2;
            Assert.AreEqual(doubleValue, 6);
        }
    }
