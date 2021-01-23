    class Base
    {
       public virtual void M() { }
    }
    
    class Derived : Base
    {
       public sealed override void M() { }
    }
    
    class A : Derived
    {
       public override void M() { } //compile error, M is sealed in Derived
    }
