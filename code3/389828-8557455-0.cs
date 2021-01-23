    interface ITestInterface
    {
        void Test();
        string Test2();
    }
    public class TestBase : ITestInterface
    {
        #region ITestInterface Members
        public void Test()
        {
            System.Console.WriteLine("Feed");
        }
        public string Test2()
        {
            return "Feed";
        }
        #endregion
    }
    public class TestChild : TestBAse, ITestInterface
    {
        public void Test()
        {
            System.Console.WriteLine("Feed1");
        }
    }
    public static void Main(){
        TestChild f = new TestChild();
        f.Test();
        
        var i = f as ITestInterface;
        
        i.Test();
        i.Test2();//not implemented in child but called from base.
    }
