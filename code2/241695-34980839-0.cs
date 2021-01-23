    [TestClass]
    public abstract class BaseTest
    {
        #region Properties
        public TestContext TestContext { get; set; }
        public string Class
        {
            get { return this.TestContext.FullyQualifiedTestClassName; }
        }
        public string Method
        {
            get { return this.TestContext.TestName; }
        }
        #endregion
        #region Methods
        protected virtual void Trace(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
            Output.Testing.Trace.WriteLine(message);
        }
        #endregion
    }
    [TestClass]
    public class SomeTest : BaseTest
    {
        [TestMethod]
        public void SomeTest1()
        {
            this.Trace(string.Format("Yeah: {0} and {1}", this.Class, this.Method));
        }
    }
