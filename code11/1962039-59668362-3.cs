    [Fact]
    public async Task UpdateState_StateHasBeenUpdated_HttpOk()
    {
        //arrange
        var state = new RedisServiceModel();
        var redisServiceMock = new Mock<IRedisService>();
        redisServiceMock.Setup(x => x.UpdateStateAsync(It.Is<RedisServiceModel>(y => y == state))).ReturnsAsync(state);
        var testController = new TestController(redisServiceMock.Object);
        // act
        var statusResult = await testController.UpdateStates(state);
        // assert
        redisServiceMock.Verify(x => x.UpdateStateAsync(It.Is<RedisServiceModel>(y => y == state)));
        Assert.True(statusResult is HttpStatusCode.OK);
    }
