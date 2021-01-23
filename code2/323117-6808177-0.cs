    //Arange
    string storeValue = "testname";
    var dbConfigMock = MockRepository.GenerateMock<DataBaseConfiguration>();
    dbConfigMock.Expect(x => x.Store(storeValue));
    StoreManager sm = new StoreManager(dbConfigMock);
    //Act
    sm.Store(storeValue);
    //Assert
    dbConfigMock.AssertWasCalled(x => x.Store(storeValue));
