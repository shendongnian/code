    Fact(DisplayName = "AddUserSettingsAsync - InvalidOperationException")]
    [Trait("Category", "Unit Test")]
    public async Task SettingsStoreAddUserSettingsTestWithException() {
        //Arrange
        string userObject = Guid.NewGuid().ToString();
        string correlationId = Guid.NewGuid().ToString();
        string body = File.ReadAllText("TestData/userSettings.json");
        UserSettingsObject userSettingsObject = JsonConvert.DeserializeObject<UserSettingsObject>(body);
        var iFunctionEnvironment = TestHelpers.GetEnvironmentVariable("Test");
        Uri.TryCreate("http://localhost", UriKind.Absolute, out Uri uri);
        var iblobStorageRepositoryMoq = new Mock<IBlobStorageRepository>();
        iblobStorageRepositoryMoq
            .Setup(mock => mock.Add(It.IsAny<ILogger>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ThrowsAsync(new Exception("Function Add threw an exception"));
        var iblobStorageRepository = iblobStorageRepositoryMoq.Object;
        SettingsStore settingsStore = new SettingsStore(iFunctionEnvironment, iblobStorageRepository);
        //Act
        Exception exception = await Assert.ThrowsAsync<InvalidOperationException>(() => settingsStore.AddUserSettingsAsync(logger, correlationId, userSettingsObject, userObject));
        //Assert
        Assert.Equal("Function Add threw an exception", exception.Message);
        Assert.Null(exception.InnerException);
    }
