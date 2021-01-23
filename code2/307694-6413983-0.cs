    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ranges = new Ranges();
            int sum = ranges.CountOccurrences(11);
            Assert.AreEqual(128, sum);
        }
    }
