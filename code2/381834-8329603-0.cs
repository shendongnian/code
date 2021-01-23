    public class BaseClass
    {
        public virtual void DoSomething()
        {
            Trace.Write("base class");
        }
    }
    public class DerivedClass : BaseClass
    {
        public new void DoSomething()
        {
            Trace.Write("derived class");
        }
    }
