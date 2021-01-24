    class Derived : Base, ICloneable {
      // Please, note that now we have new Clone method which returns Derived instance
      public new Derived Clone() {
        ...
      }
      // This ICloneable implementation will call Derived Clone()
      object ICloneable.Clone() => Clone();
    }
    ...
    // Derived ICloneable.Clone() will be called
    // which executes "new Derived Clone()" method
    object clone = (test as IClonable).Clone();
