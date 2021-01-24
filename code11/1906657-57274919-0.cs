    [TestMethod]
    public void ShouldReturnNegativeWhenMsgIsAbc() {
        //Arrange
        var myPublisherMock = new Mock<IPublisher>();
        string msg = "abc";
        long expected = -1;
        myPublisherMock
            .Setup(m => m.GetMessageCount(msg))
            .Returns(expected)
            .Verifiable();
        var subject = new SubjectUnderTest(myPublisherMock.Object);
        //Act
        subject.SomeMethod(msg);
        //Assert
        myPublisherMock.Verify();
    }
