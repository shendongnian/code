    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<Boo> moqBoo = new Mock<Boo>();
            moqBoo.Setup(IEnumerableHasExpectedNumberOfElements(10));
            // ACT
            moqBoo.Verify(IEnumerableHasExpectedNumberOfElements(10));
        }
        private static Expression<Action<Boo>> IEnumerableHasExpectedNumberOfElements(int expectedNumberOfElements)
        {
            return b => b.Add(It.Is<IEnumerable<Invoice>>(ie => ie.Count() == expectedNumberOfElements));
        }
    }
    public class Boo
    {
        public void Add<T>(IEnumerable<T> item) where T : class, new()
        {
        }
    }
    public class Invoice
    {
        
    }
