    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodIsBeetween()
        {
            Assert.IsTrue(5.0.IsBetweenII(5.0, 5.0));
            Assert.IsFalse(5.0.IsBetweenEI(5.0, 5.0));
            Assert.IsFalse(5.0.IsBetweenIE(5.0, 5.0));
            Assert.IsFalse(5.0.IsBetweenEE(5.0, 5.0));
            Assert.IsTrue(5.0.IsBetweenII(4.9, 5.0));
            Assert.IsTrue(5.0.IsBetweenEI(4.9, 5.0));
            Assert.IsFalse(5.0.IsBetweenIE(4.9, 5.0));
            Assert.IsFalse(5.0.IsBetweenEE(4.9, 5.0));
            Assert.IsTrue(5.0.IsBetweenII(5.0, 5.1));
            Assert.IsFalse(5.0.IsBetweenEI(5.0, 5.1));
            Assert.IsTrue(5.0.IsBetweenIE(5.0, 5.1));
            Assert.IsFalse(5.0.IsBetweenEE(5.0, 5.1));
            Assert.IsTrue(5.0.IsBetweenII(4.9, 5.1));
            Assert.IsTrue(5.0.IsBetweenEI(4.9, 5.1));
            Assert.IsTrue(5.0.IsBetweenIE(4.9, 5.1));
            Assert.IsTrue(5.0.IsBetweenEE(4.9, 5.1));
            Assert.IsFalse(5.0.IsBetweenII(5.1, 4.9));
            Assert.IsFalse(5.0.IsBetweenEI(5.1, 4.9));
            Assert.IsFalse(5.0.IsBetweenIE(5.1, 4.9));
            Assert.IsFalse(5.0.IsBetweenEE(5.1, 4.9));
        }
    }
