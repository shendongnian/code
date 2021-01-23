    public class Base
    {
      public Base(Base child)
      { Child = child; }
      public Base Child { get; private set; }
    }
    
    public class Derived
    {
     public Derived(Derived child) : base(child)
     {  }
     public new Derived Child 
     { get { return (Derived)base.Child; } }
    }
