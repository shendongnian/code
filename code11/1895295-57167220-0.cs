    [Test]
    public async Task MainClass_Should_Stop() {
        //Arrange
    	var dependency = MockRepository.GenerateMock<IDependency>();
        var subject = new MainClass(dependency);
        var expectedDelay = 200;
        var expectedCalls = 2;
    
        //Act
        subject.Start();
        await Task.Delay(expectedDelay);
        subject.Stop();
        await Task.Delay(100);
    
        //Assert
    	dependency.AssertWasCalled(
          dependency => dependency.Foo(),
          options => options.Repeat.Times(expectedCalls)
      );
    }
