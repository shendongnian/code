    [Test]
    void ProxyUser_does_something()
    {
        var proxyStub = MockRepository.CreateStub<IProxy>();
        var proxyUser = new ProxyUser(delegate { return proxyStub; });
        proxyUser.DoSomething();
        // make assertions...
    }
