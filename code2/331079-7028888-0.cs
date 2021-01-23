    public class Base 
    {
      public Base() : this(null, null)
      {
      }
      public Base(SomeClass param1) : this(param1, null)
      {
      }
      public Base(SomeClass param1, OtherClass param2)
      {
        if (param1 != null)
        {
          // initialise param1
        }
        if (param2 != null)
        {
          // initialise param2
        }
      }
    }
    public class Derived : Base
    {
      public Derived() : this(null, null)
      {
      }
      public Derived(SomeClass param1) : this(param1, null)
      {
      }
      public Derived(SomeClass param1, OtherClass param2) : base(param1, param2)
      {
      }
    } 
