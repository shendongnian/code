    class Derived : Base {
      // Note that now we have new Clone method which returns Derived instance (not Base one)
      public new Derived Clone() {
        ...
      }
    }
    ...
    Derived test = new Derived();
    Derived duplicate = test.Clone();
