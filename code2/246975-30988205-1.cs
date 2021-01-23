    [TestClass]
    public class ActionExtensionsTests
    {
        [TestMethod]
        public void IgnoreException()
        {
            Action justThrow = () => { throw new InvalidOperationException(); };
            justThrow.IgnoreExceptions();
        }
        [TestMethod]
        public void AddIgnoreException()
        {
            Action justThrow = () => { throw new InvalidOperationException(); };
            var newAction = justThrow.AddIgnoreExceptions();
            newAction();
        }
    }
