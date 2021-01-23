    // Setup
    var spy = new DependencySpy;
    MyClass myclass = new MyClass(spy);
    spy.ClearResetCallCount();
    // Exercise
    myclass.Clear();
    // Validate
    Assert.AreEqual(1, spy.ResetCallCount);
