    public class Base
    {
    public virtual void SomeMethod()
    {
    }
    }
    
    public class Derived : Base
    {
    public override void SomeMethod()
    {
    }
    }
    
    ...
    
    Base b = new Derived();
    b.SomeMethod();
