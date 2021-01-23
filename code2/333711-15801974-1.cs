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
        virtual void IInterfaceA.Method()
        {
           ...
        }
        virtual void IInterfaceB.Method()
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
