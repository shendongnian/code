    // Reaches too far.  Makes this depend on the interface of SomeProperty
    this.Context.SomeProperty.DoSomething();
    // ...
    // Not reaching too far.  Only depends on Context.
    // This might forward to SomeProperty.DoSomething()
    this.Context.DoSomething();
