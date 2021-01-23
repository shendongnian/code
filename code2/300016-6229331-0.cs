    public interface ITestClass
    {
        void Test(Type a, Type b);
    }
    public class TestClass : ITestClass
    {
        //implement the interface here
        public void Test(Type a, Type b)
        {
            Test(a, b);
        }
        //you actual implementation here
        public void Test(Type a, Type b, Type c = null)
        {
            //implementation
        }
    }
