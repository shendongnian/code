    [TestMethod]
    public async Task MainClass_Should_Stop() {
        //Arrange
        var dependency = Substitute.For<IDependency>();
        var subject = new MainClass(dependency);
        var expectedDelay = 200;
        var expectedCalls = 2;
        //Act
        subject.Start();
        await Task.Delay(expectedDelay);
        subject.Stop();
        //Assert
        dependency.Received(expectedCalls).Foo();
    }
