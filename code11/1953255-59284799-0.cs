    [TestClass]
    public class Test
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Exception caughtException = null;
            try
            {
                var test = new Mock<SomeClass>(null).Object;
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }
            Assert.IsInstanceOfType(caughtException.InnerException, typeof(ArgumentNullException));
        }
    }
    public abstract class SomeClass
    {
        ISomeDependency someDependency;
        public SomeClass(ISomeDependency someDependency)
        {
            if (someDependency == null)
            {
                throw new ArgumentNullException(nameof(someDependency));
            }
            this.someDependency = someDependency;
        }
    }
