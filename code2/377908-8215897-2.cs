    [TestClass]
    public abstract class BaseUnitTest
    {
        public BaseUnitTest(){}
        private TestContext testContextInstance;        
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }        
        [TestMethod]
        public void can_run_this_test_for_each_derived_class()
        {
            Assert.IsNotNull(this.ReturnMeSomething());
        }
        protected abstract string ReturnMeSomething();
    }
    
    [TestClass]
    public class Derived1 : BaseUnitTest
    {
    
        protected override string ReturnMeSomething()
        {
            return "test1";
        }
    }
    
    [TestClass]
    public class Derived2 : BaseUnitTest
    {
        protected override string ReturnMeSomething()
        {
            return null;
        }
    }
