    var transactionManager = MockRepository.GenerateMock<IPlatformTransactionManager>();
    var mockDelegate = MockRepository.GenerateMock<ITransactionCallback>();
    mockDelegate.Stub(t => t.DoInTransaction(null)).IgnoreArguments().Do(...);
    var template = new TransactionTemplate(transactionManager);
    template.Execute(mockDelegate);
