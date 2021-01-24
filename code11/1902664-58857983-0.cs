    var relationalCommandMock = new Mock<IRelationalCommand>();
    relationalCommandMock
        .Setup(m => m.ExecuteNonQuery(It.IsAny<IRelationalConnection>(), It.IsAny<IReadOnlyDictionary<string, object>>()))
        .Returns((IRelationalConnection providedConnection, IReadOnlyDictionary<string, object> providedParameterValues) => executeSqlCommandResult);
    relationalCommandMock
        .Setup(m => m.ExecuteNonQueryAsync(It.IsAny<IRelationalConnection>(), It.IsAny<IReadOnlyDictionary<string, object>>(), It.IsAny<CancellationToken>()))
        .Returns((IRelationalConnection providedConnection, IReadOnlyDictionary<string, object> providedParameterValues, CancellationToken providedCancellationToken) => Task.FromResult(executeSqlCommandResult));
    var relationalCommand = relationalCommandMock.Object;
    
    var rawSqlCommandMock = new Mock<RawSqlCommand>(MockBehavior.Strict, relationalCommand, new Dictionary<string, object>());
    rawSqlCommandMock.Setup(m => m.RelationalCommand).Returns(relationalCommand);
    rawSqlCommandMock.Setup(m => m.ParameterValues).Returns(new Dictionary<string, object>());
    var rawSqlCommand = rawSqlCommandMock.Object;
    
    var rawSqlCommandBuilderMock = new Mock<IRawSqlCommandBuilder>();
    
    rawSqlCommandBuilderMock
        .Setup(m => m.Build(It.IsAny<string>(), It.IsAny<IEnumerable<object>>()))
        .Returns((string providedSql, IEnumerable<object> providedParameters) => rawSqlCommand);
        
    var rawSqlCommandBuilder = rawSqlCommandBuilderMock.Object;
    
    var serviceProviderMock = new Mock<IServiceProvider>();
    serviceProviderMock.Setup(m => m.GetService(It.Is<Type>(t => t == typeof(IConcurrencyDetector)))).Returns((Type providedType) => Mock.Of<IConcurrencyDetector>());
    serviceProviderMock.Setup(m => m.GetService(It.Is<Type>(t => t == typeof(IRawSqlCommandBuilder)))).Returns((Type providedType) => rawSqlCommandBuilder);
    serviceProviderMock.Setup(m => m.GetService(It.Is<Type>(t => t == typeof(IRelationalConnection)))).Returns((Type providedType) => Mock.Of<IRelationalConnection>());
    var serviceProvider = serviceProviderMock.Object;
    
    var databaseFacadeMock = new Mock<DatabaseFacade>(MockBehavior.Strict, mockedDbContext);
    databaseFacadeMock.As<IInfrastructure<IServiceProvider>>().Setup(m => m.Instance).Returns(serviceProvider);
    var databaseFacade = databaseFacadeMock.Object;
    
    Mock.Get(mockedDbContext).Setup(m => m.Database).Returns(databaseFacade);
