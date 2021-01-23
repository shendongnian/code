    MockRepository mocks = new MockRepository(MockBehavior.Default);
    var dep = mocks.Create<IDependency>();
    
    MyClass myclass = new MyClass(dep.Object);
    
    // setting up the mock just before calling the method under test
    // will ignore any prior call to IDependency.Reset
    int resetTimes = 0;
    dep.Setup(s => s.Reset()).Callback(() => resetTimes++);
    
    myclass.Clear();
    mocks.VerifyAll();
    Assert.That(resetTimes, Is.EqualTo(1));
