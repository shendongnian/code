    class base
    {
      protected virtual void method()
      {
         // do some stuff in base class, something common for all derived classes
      }
    }
    class derived :  base
    {
      public override void method()
      {
        base.method(); // call method from base
        // do here some more work related to this instance of object
      }
    }
