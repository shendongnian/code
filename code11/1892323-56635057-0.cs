    // ARRANGE
    var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
    handlerMock
       .Protected()
       // Setup the PROTECTED method to mock
       .Setup<Task<HttpResponseMessage>>(
          "SendAsync",
          ItExpr.IsAny<HttpRequestMessage>(),
          ItExpr.IsAny<CancellationToken>()
       )
       // prepare the expected response of the mocked http call
       .ReturnsAsync(new HttpResponseMessage()
       {
          StatusCode = HttpStatusCode.OK,
          Content = new StringContent("[{'id':1,'value':'1'}]"),
       })
       .Verifiable();
     
    // use real http client with mocked handler here
    var httpClient = new HttpClient(handlerMock.Object)
    {
       BaseAddress = new Uri("http://test.com/"),
    };
     
    var subjectUnderTest = new MyTestClass(httpClient);
     
    // ACT
    var result = await subjectUnderTest
       .GetSomethingRemoteAsync('api/test/whatever');
     
    // ASSERT
    result.Should().NotBeNull(); // this is fluent assertions here...
    result.Id.Should().Be(1);
     
    // also check the 'http' call was like we expected it
    var expectedUri = new Uri("http://test.com/api/test/whatever");
     
    handlerMock.Protected().Verify(
       "SendAsync",
       Times.Exactly(1), // we expected a single external request
       ItExpr.Is<HttpRequestMessage>(req =>
          req.Method == HttpMethod.Get  // we expected a GET request
          && req.RequestUri == expectedUri // to this uri
       ),
       ItExpr.IsAny<CancellationToken>()
    );
  
