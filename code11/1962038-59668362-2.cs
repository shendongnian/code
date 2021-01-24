    [Fact]
    public async Task UpdateState_StateHasNotBeenModified_HttpNotModified() {
        //arrange
        var state = new RedisServiceModel();
        var redisServiceMock = new Mock<IRedisService>();
        redisServiceMock
            .Setup(x => x.UpdateStateAsync(It.Is<RedisServiceModel>(y => y == state)))
            .ReturnsAsync(state);
        var testController = new TestController(redisServiceMock.Object);
        // act
        var statusResult = await testController.UpdateStates(null);
        // assert
        redisServiceMock.Verify(x => x.UpdateStateAsync(It.Is<RedisServiceModel>(y => y == state)), Times.Once);
        Assert.True(statusResult is HttpStatusCode.NotModified);
    }
