    public class BaseClass
    {
        public virtual void A() { }
    	public virtual void B() { }
    }
    
    public class SubClass : BaseClass
    {
        public virtual void A() { B(); }
        // legal, you can do this and B() is now hidden internally in SubClass,
        // but to outside world BaseClass's B() is still the one used.
    	private new void B() { }
    }
    // ...
 
    SubClass sc = new SubClass();
    BaseClass bc = new BaseClass();
 
    // both of these call BaseClass.B() because we are outside of class and can't
    // see the hide SubClass.B().
    sc.B();
    bc.B();
    // this calls SubClass.A(), which WILL call SubClass.B() because the hide
    // SubClass.B() is visible within SubClass, and thus the hide hides BaseClass.B()
    // for any calls inside of SubClass.
    sc.A();
