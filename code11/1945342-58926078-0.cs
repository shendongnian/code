    [Fact]
    public async Task Returns_OK_With_Tar_Tracker_Response() {
        //arrange    
        string expected = "test";
        var mockRepo = new Mock<ITARRepository>();
        mockRepo
            .Setup(repo => repo.Get<string>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expected);
    
        var controller = new TARTrackerController(Logger, mockRepo.Object);
    
        //act
        var result = await controller.GetTARTrackerResponse(12345);    
    
        //assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var actual = objectResult.Value;
        Assert.IsType<string>(actual);
        Assert.AreEqual(expected, actual);
    }
