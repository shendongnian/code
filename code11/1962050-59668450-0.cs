        [Fact]
        public void UpdateState_StateHasNotBeenModified_HttpNotModified()
        {
            //arrange
            var state = new RedisServiceModel();
            var redisServiceMock = new Mock<IRedisService>();
            redisServiceMock.Setup(x => x.UpdateStateAsync(It.Is<RedisServiceModel>(y => y == state))).ReturnsAsync(state);
            var testController = new TestController(redisServiceMock.Object);
            // act
            var statusResult = testController.UpdateStates(null);
            // assert
            redisServiceMock.Verify(x => x.UpdateStateAsync(It.Is<RedisServiceModel>(y => y == null)), Times.Once);
            Assert.True(statusResult.Result is HttpStatusCode.NotModified);
        }
