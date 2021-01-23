    // don't mark this one as TestClass!
    public abstract class MyBaseFixture
    {
        protected ITest mockInstance;
    
        [TestMethod]
        public void Test1 ()
        {
            Assert(this.mockInstance.Func1() == 0);
        }
    }
    
    [TestClass]
    public class MyConcreteFixture : MyBaseFixture
    {
        [TestInitialize]
        public void Setup()
        {
            this.mockInstance = new ConcreteInstance1();
        }
    }    
    
    [TestClass]
    public class MyOtherConcreteFixture : MyBaseFixture
    {
        [TestInitialize]
        public void Setup()
        {
            this.mockInstance = new ConcreteInstance2();
        }
    }
