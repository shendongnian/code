    [Test]
    void MyClass_does_something()
    {
        var proxyStub = MockRepository.CreateStub<IProxy>();
        var myClass = new MyClass(delegate { return proxyStub; });
        myClass.DoSomething();
        // make assertions...
    }
