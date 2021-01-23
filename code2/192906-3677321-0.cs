    [Fact]
    public void RegisterWithAnonymousParameter()
    {
      // Fixture setup
      Fixture fixture = new Fixture();
      string knownText = "This text is not anonymous";
      fixture.Register<int, string, IMyInterface>((i, s) => 
        new FakeMyInterface(i, knownText));
      // Exercise system
      MyClass sut = fixture.CreateAnonymous<MyClass>();
      // Verify outcome
      Assert.NotNull(sut);
      // Teardown
    }
