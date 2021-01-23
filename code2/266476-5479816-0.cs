    public class BaseClass
    {
        private int one = 1;
    }
    
    public class SubClass : BaseClass
    {
        private int two = 2;
    }
    
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            SubClass test = new SubClass();
            PrivateObject privSub = new PrivateObject(test, new PrivateType(typeof(SubClass)));
            PrivateObject privBase = new PrivateObject(test, new PrivateType(typeof(BaseClass)));
    
            Assert.AreNotEqual<int>(0, (int)privBase.GetFieldOrProperty("one"));
            Assert.AreNotEqual<int>(0, (int)privSub.GetFieldOrProperty("two"));
        }
    }
