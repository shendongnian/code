    public class Base
    {
    public virtual void SomeOtherMethod()
    {
    }
    }
    
    public class Derived : Base
    {
    public new void SomeOtherMethod()
    {
    }
    }
    
    ...
    
    
    Base b = new Derived();
    Derived d = new Derived();
    b.SomeOtherMethod();
    d.SomeOtherMethod();
