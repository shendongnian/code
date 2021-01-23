    public interface IMyClass
    {
        void DoSomething();
    }
    
    public abstract class MyClassBase : IMyClass
    {
        abstract void DoSomething();
        // more code for the base class if you need it.
    }
    public class MyClassA : MyClassBase
    {
        void virtual DoSomething()
        {
            // implementation here
        }
    }
    public class MyClassB : MyClassBase
    {
        void virtual DoSomething()
        {
            // implementation here
        }
    }
    public class MyClassC : MyClassBase
    {
        void virtual DoSomething()
        {
            // implementation here
        }
    }
    // etc.
