    [Test]
    public void PassingNullParamShouldRaiseError() {
        // Arrange
        var mockLog = new Mock<ILog>();
        var sut = new Mock<Test>() {
            CallBase = true //Important to be able to call base member
        };
        //override default behavior of protected logger
        sut.Protected()
            .Setup<ILog>("Logger")
            .Returns(mockLog.Object);
        // Act
        sut.Object.DoSomething(null);
        // Assert
        mockLog.Verify(x => x.Error("Exception raised!", It.IsAny<Exception>()), Times.Once());
    }
