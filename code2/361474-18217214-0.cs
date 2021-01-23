    public abstract class Base<T> where T : Base<T>
    {
        public T Method()
        {
            return ThisDerived;
        }
        // It is worth to do this if you need the "this" of the derived class often in the base class
        protected abstract T ThisDerived { get; }
    }
    public class Derived1 : Base<Derived1>
    {
        protected override Derived1 ThisDerived{ get { return this; } } 
    }
    public class Derived2 : Base<Derived2>
    {
        protected override Derived2 ThisDerived { get { return this; } }
    }
