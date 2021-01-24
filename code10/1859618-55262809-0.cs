    mockStateFixture.MockCouchDbClient.Setup(x => x.AuthenticatedQuery(
        It.IsAny<Func<Task<HttpResponseMessage>>>(),
        NamedHttpClients.COUCHDB,
        httpClient))
        .ReturnsAsync(httpResponseMessage);
