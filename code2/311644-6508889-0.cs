    class FirstRole : Role {
      public void FirstMethod() { ... }
      public void SecondMethod() { ... }
    }
    
    class SecondRole : Role {
      ...
    }
    class MyClass : Does<FirstRole>, Does<SecondRole> {
       
    }
