    class Base {
      // We can't declare this method as virtual: Derived class will return Derived 
      public Base Clone() {
        ...
      }
    }
    ...
    Base test = new Base();
    Base duplicate = test.Clone(); 
