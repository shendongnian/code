    //Arrange
    Mock<IProcessor> mock = new Mock<IProcessor>();
    mock.Setup(_ => _.Process(It.IsAny<CreateRequest>()))
        .Callback((CreateRequest arg) => arg.Successful = true);
    var subject = new TheClassIAmUnitTesting(mock.Object);
    //Act
    subject.SomeMethod();
