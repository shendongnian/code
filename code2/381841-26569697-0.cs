    public class BaseClass
    {
        public virtual void DoSomething()
        {
            Trace.Write("base class");
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void DoSomething()
        {
            Trace.Write("derived class");
        }
        public void BaseDoSomething()
        {
            base.DoSomething();
        }
    }
