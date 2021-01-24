            var httpMessageHandler = new Mock<HttpMessageHandler>();
            
            // Setup Protected method on HttpMessageHandler mock.
            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "GetAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync((HttpRequestMessage request, CancellationToken token) =>
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    // Setup your response for testing here.
                    return response;
                });
            var client = new HttpClient(httpMessageHandler.Object);
