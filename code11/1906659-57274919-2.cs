    [TestMethod]
    public void ShouldReturnNegativeWhenMsgIsAbc() {
        //Arrange
        var myPublisherMock = new Mock<IPublisher>();
        long expected = -1;
        var subject = new Publisher(myPublisherMock.Object);
        //Act
        var actual = subject.GetMessageCount("abc");
        //Assert
        actual.Should().Be(expected); //FluentAssertion
        myPublisherMock.Verify(_ => _.GetMessageCount(It.IsAny<string>()), Times.Never);
    }
    
