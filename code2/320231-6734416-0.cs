    public abstract class abc
    {
        // Everything you want here, but not "Test()".
    }
    public class def : abc
    {
    }
    public class ghi : def, ITestable
    {
        public void ITestable.Test()
        {
        }
    }
    
    public interface ITestable
    {
        void Test();
    }
