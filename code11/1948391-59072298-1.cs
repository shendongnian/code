    var serviceMock = new Mock<IMyService>();
    serviceMock.Setup(s => s.CallSomethingReturningAsyncStream()).Returns(GetTestValues);
    
    var thing = new Thing(serviceMock.Object);
    var result = await thing.MyMethodIWantToTest();
    Assert.Equal("foo", result[0]);
    Assert.Equal("bar", result[1]);
