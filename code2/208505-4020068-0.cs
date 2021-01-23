    //Arrange
    mockedInterface.Stub(x => x.SomeMethod1()).Returns(2);
    
    ...
    //Assert
    mockedInterface.AssertWasCalled(x => x.SomeMethod1());
    mockedInterface.AssertWasCalled(x => x.SomeMethod2());
    Assert.AreEqual(...); // stanmdard NUnit asserttions
