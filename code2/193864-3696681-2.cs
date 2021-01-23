    interface ITestable
    {
        bool DoTest();
    }
    
    interface ITest<T> : ITestable
    {
        T t { get; }
    }
    
    public class TestTest 
    {       
        ITestable myTest;
    }
