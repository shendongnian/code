    var searchIndexClientMock = new Mock<ISearchIndexClient>();
    searchIndexClientMock
        .Setup(x => x.Documents.Index(It.IsAny<IndexBatch<Document>>(), It.IsAny<SearchRequestOptions>()))
        .Returns(It.IsAny<DocumentIndexResult>()).Callback(() => IndexBatch.Upload(It.IsAny<IEnumerable<Document>>()));
    var pushFunction = new SearchIndexWriter();
    Search search = new Search();
    await pushFunction.Write(searchIndexClientMock.Object, search);
    //Assert, Verify checks
}
