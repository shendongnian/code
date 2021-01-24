    public async Task Write_Success() {
        //Arrange
        var serviceMock = new Mock<ISearchService>();
        serviceMock
            .Setup(_ => _.UploadContents(It.IsAny<ISearchIndexClient>(), It.IsAny<IReadOnlyCollection<It.AnyType>>())
            .ReturnsAsync(new object());
    
        var searchIndexClientMock = Mock.Of<ISearchIndexClient>();
        
        var pushFunction = new SearchIndexWriter(serviceMock.Object);
    
        Search search = new Search();
    
        //Act
        await pushFunction.Write(searchIndexClientMock.Object, search);
    
        //Assert, Verify checks
        //...
    }
