    public async Task Service_Should_AddAsync() {
        //Arrange
        int id = 1;
        var mock = new Mock<ICrud>();
        var newModel = new Model { Id = id };
        mock.Setup(x => x.AddAsync(It.IsAny<Model>())).Returns(Task.CompletedTask);
        var service = new Service(mock.Object);
        //Act
        await service.AddAsync(newModel);
        //Assert
        //verify that the mock was invoked with the given model.
        mock.Verify(x => x.AddAsync(newModel));
        
    }
