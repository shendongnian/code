    class Test {
      private readonly Mock<IHttpClientFactory> httpClientFactory;
      private readonly MockHttpMessageHandler handler;
    
      constructor(){
        this.handler = new MockHttpMessageHandler();
        this.httpClientFactory = new Mock<IHttpClientFactory>();
        this.httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
            .Returns(handler.ToHttpClient());
      }
    
      public async Task Test(){
        // Arrange
        this.handler.Expect("api/DBU/data")
                    .Respond(HttpStatusCode.Ok);
        var sut = this.CreateSut();
        
        // Act
        await sut.Run(...);
        
        // Assert
        this.handler.VerifyNoOutstandingExpectation();       
      }
       
      private UpdateDB CreateSut() => new UpdateDB(this.httpClientFactory.Object);
    }
