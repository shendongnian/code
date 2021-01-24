    public async Task SampleTest() {
        //Arrange
        var httpResponse = new HttpResponseMessage() {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("hello")
        };
        var _mockRetryHttpRequest = new Mock<IRetryHttpRequest>();
        _mockRetryHttpRequest
            .Setup(_ => _.ExecuteAsync(It.IsAny<Func<HttpRequestMessage>>(), It.IsAny<HttpClient>()))
            .ReturnsAsync(httpResponse);
        var lgService = new LibraryService(_mockRetryHttpRequest.Object);
        //Act
        HttpResponseMessage response = await lgService.GetResponse(new Request(), null);
        //Assert
        response.Should().NotBeNull()
            .And.Be(httpResponse);
    }
    
