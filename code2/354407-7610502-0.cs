    // I hope you have an interface to abstract DbContext?
    var dbContextMock = MockRepository.GenerateMock<IDbContext>();
    // setup expectations for DbContext mock
    dbContextMock.Expect(...)
    // bind mock of the DbContext to property of repository.DbContext
    ducumentMockRepository.Expect(mock => mock.DbContext)
                          .Return(dbContextMock)
                          .Repeat()
                          .Any();
