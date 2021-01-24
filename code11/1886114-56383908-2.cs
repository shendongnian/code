    [TestMethod]
    public void TheUnitTest() {
        //Arrange
        Mock<IProcessor> mock = new Mock<IProcessor>();
    
        mock.Setup(_ => _.Process(It.IsAny<CreateRequest>()))
            .Callback((CreateRequest arg) => arg.Successful = true)
            .Verifiable();
    
        var subject = new TheClassIAmUnitTesting(mock.Object);
    
        //Act
        subject.SomeMethod();
    
        //Assert
        mock.VerifyAll();
    }
