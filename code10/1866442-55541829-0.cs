    mockStateFixture.MockCouchDbClient.SetupSequence(x => x.AuthenticatedQuery(
        It.IsAny<Func<HttpClient, Task<HttpResponseMessage>>>(),
        NamedHttpClients.COUCHDB,
        httpClient))
      .ReturnsAsync(httpResponseMessageForProfileRecordByUpn)
      .ReturnsAsync(httpResponseMessageForCreatedReturnResult);
