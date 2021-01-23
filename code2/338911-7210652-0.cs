    interface IFoo {
      void Method(); 
    }
    
    class C1 : IFoo {
      // Implicitly implements IFoo.Method
      public void Method() { }
    }
    
    class C2 : IFoo {
      // Explicitly implements IFoo.Method
      void IFoo.Method() { }
    }
