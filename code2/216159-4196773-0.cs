    abstract class Class1 {
      protected void Method1() {
        ...
      }
    }
    
    class Class2 : Class1 {
      public void Method2() {
        Method1(); // Legal
      }
    }
    
    class Class3 { 
      public void Example() {
        Class2 local = new Class2();
        local.Method2();  // Legal
        local.Method1();  // Illegal since Method1 is protected
      }
    }
