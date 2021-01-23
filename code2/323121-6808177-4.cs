    string storeValue = "testname";
    DataBaseConfigurationTest dbConfigStub = new DataBaseConfigurationTest();
    StoreManager sm = new StoreManager(dbConfigStub);
    sm.Store(storeValue);
    Assert.AreEqual(1, dbConfigStub.TimesCalled);
    Assert.AreEqual(storeValue, dbConfigStub.LastNameStored);
