    [TestClass]
    public class SomeClassTest
    {
        private class DummySomeClass : SomeClass
        {
            public bool IsHappyWrapper(string mood)
            {
                return IsHappy(mood);
            }
        }
        [TestMethod]
        public void SomeTest()
        {
            var myClass = new DummySomeClass();
            Assert.IsTrue(myClass.IsHappyWrapper("Happy"));
        }
    }
