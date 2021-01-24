    var dbProviderMock = new Mock<IDbConnectionsProvider>(MockBehavior.Loose);
    dbProviderMock
        .Setup(p => p.CoreDbProcessesConnection)
        .Returns(new SqlConnection(...));
    DatabaseManager databaseManager = new DatabaseManager(dbProviderMock.Object);
  
    var actual = databaseManager.IsFailureProcessStatus(step1Dto.Step, dateTime);
    Assert.IsTrue(actual);
