    //Arrange
    var repository = new Mock<INewVMRequestRepository>();
    var sut = new NewVMRequestRejectedConsumer(repository.Object);
    
    //Act
    sut.Consume(Mock.Of<ConsumeContext<INewVMRequestRejected>>(m =>
        m.Message.RequestId == "id" && m.Message.Reason == "reason"));
    
    //Assert
    repository.Verify(m => m.AddReasonForRejection("id", "reason"), Times.Once);
