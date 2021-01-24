    public async Task SampleTest() {
        //Arrange
        var content = new StringContent("{}", Encoding.UTF8, "application/json");
        var httpResponse = new HttpResponseMessage() {
            StatusCode = HttpStatusCode.OK,
            Content = content
        };
        var _mockRetryHttpRequest = new Mock<IRetryHttpRequest>();
        _mockRetryHttpRequest
            .Setup(_ => _.ExecuteAsync(It.IsAny<Func<HttpRequestMessage>>(), It.IsAny<HttpClient>(), It.IsAny<int>()))
            .ReturnsAsync(httpResponse);
        var lgService = new LibraryService(_mockRetryHttpRequest.Object);
        //Act
        var response = await lgService.GetResponseForSearch(new SearchRequest(), null);
        //Assert
        response.Should().NotBeNull();
    }
    
