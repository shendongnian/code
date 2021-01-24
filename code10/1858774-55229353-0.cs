    [TestMethod]
    public void Ctor_ValidParams_CreatesObject()
    {
        // Arrange
        ILogger baseLogger =  MockRepository.GenerateMock<ILogger>();
        IMyClassLogger logger = MockRepository.GenerateStrictMock<IMyClassLogger>();
        logger.Stub(_ => _.BaseLogger).Return(baseLogger);
        // Act
        var result = new MyClassDataAccess(logger);
        // Assert
        Assert.IsNotNull(result);
    }
