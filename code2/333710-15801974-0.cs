    public interface IInterfaceA
    {
        void Method();
    }
    public interface IInterfaceB
    {
        void Method();
    }
    public class Base : IInterfaceA, IInterfaceB
    {
        public virtual void IInterfaceA.Method()
        {
           ...
        }
        public virtual void IInterfaceB.Method()
        {
           ...
        }
    }
    public class Derived : Base
    {
        public override void Method()
        {
            // Will this override IInterfaceA or IInterfaceB implementation???
        }
    }
