    public async Task Should_CreateItemAsync_When_ConnectionData_NotNull() {
        //Arrange
        //to be returned by the called mock
        var responseMock = new Mock<ItemResponse<ConnectionData>>();
        //data to be passed to the method under test
        ConnectionData data = new ConnectionData {
            ConnectionId = "some value here"
        };
        var containerMock = new Mock<Container>();
        //set the mock expected behavior
        containerMock
            .Setup(_ => _.CreateItemAsync<ConnectionData>(
                data, 
                It.IsAny<PartitionKey>(), 
                It.IsAny<ItemRequestOptions>(),
                It.IsAny<CancellationToken())
            )
            .ReturnsAsync(responseMock.Object)
            .Verifiable();
            
        var subject = new MySubjectClass(containerMock.Object);
        //Act
        await subject.AddSignalRConnectionAsync(data);
        //Assert
        containerMock.Verify(); //verify expected behavior
    }
    
